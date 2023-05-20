using FluentValidation;
using LanguageExt.Common;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using SpaceXLaunchViewer.Core.Interfaces;
using SpaceXLaunchViewer.Core.QueryModels;
using SpaceXLaunchViewer.Core.ResponseModels;
using SpaceXLaunchViewer.Infrastructure.Settings;

namespace SpaceXLaunchViewer.Infrastructure.Services;
public sealed class SpaceXApiClient : ISpaceXApiClient
{
    private const int RecordsPerRequestLimit = 10;
    private readonly AsyncRetryPolicy<HttpResponseMessage> RetryPolicy = Policy
        .HandleResult<HttpResponseMessage>(r => r.IsSuccessStatusCode is false)
        .WaitAndRetryAsync(
            retryCount: 3,
            retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
        );

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IValidator<LaunchQuery> _launchQueryValidator;
    private readonly IValidator<LaunchDetailQuery> _launchDetailQueryValidator;

    public SpaceXApiClient(
        IHttpClientFactory httpClientFactory,
        IValidator<LaunchQuery> launchQueryValidator,
        IValidator<LaunchDetailQuery> launchDetailQueryValidator)
    {
        _httpClientFactory = httpClientFactory;
        _launchQueryValidator = launchQueryValidator;
        _launchDetailQueryValidator = launchDetailQueryValidator;
    }

    public async Task<Result<LaunchDetail?>> GetLaunchByFlightNumberAsync(
        LaunchDetailQuery query)
    {
        var validationResult = await _launchDetailQueryValidator.ValidateAsync(query);
        if (validationResult.IsValid is false)
        {
            return new Result<LaunchDetail?>(
                new ValidationException(validationResult.Errors));
        }

        using var httpClient = _httpClientFactory.CreateClient(SpaceXOptions.SpaceX);

        var response = await RetryPolicy
            .ExecuteAsync(() => httpClient.GetAsync($"launches/{query.FlightNumber}"));

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<LaunchDetail>(content);
        }

        return null;
    }

    public async Task<Result<IEnumerable<Launch>?>> GetPastLaunchesAsync(
        LaunchQuery query)
    {
        var validationResult = await _launchQueryValidator.ValidateAsync(query);
        if (validationResult.IsValid is false)
        {
            return new Result<IEnumerable<Launch>?>(
                new ValidationException(validationResult.Errors));
        }

        using var httpClient = _httpClientFactory.CreateClient(SpaceXOptions.SpaceX);

        int offset = (query.PageNumber - 1) * RecordsPerRequestLimit;

        var response = await RetryPolicy
            .ExecuteAsync(() => httpClient.GetAsync($"launches/past?offset={offset}&limit={RecordsPerRequestLimit}"));

        var records = Enumerable.Empty<Launch>();
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            records = JsonConvert.DeserializeObject<IEnumerable<Launch>?>(content);
        }

        return new Result<IEnumerable<Launch>?>(records);
    }

    public async Task<Result<IEnumerable<Launch>?>> GetUpcomingLaunchesAsync(
        LaunchQuery query)
    {
        var validationResult = await _launchQueryValidator.ValidateAsync(query);
        if (validationResult.IsValid is false)
        {
            return new Result<IEnumerable<Launch>?>(
                new ValidationException(validationResult.Errors));
        }

        using var httpClient = _httpClientFactory.CreateClient(SpaceXOptions.SpaceX);

        int offset = (query.PageNumber - 1) * RecordsPerRequestLimit;

        var response = await RetryPolicy
            .ExecuteAsync(() => httpClient.GetAsync($"launches/upcoming?offset={offset}&limit={RecordsPerRequestLimit}"));

        var records = Enumerable.Empty<Launch>();
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            records = JsonConvert.DeserializeObject<IEnumerable<Launch>?>(content);
        }

        return new Result<IEnumerable<Launch>?>(records);
    }
}
