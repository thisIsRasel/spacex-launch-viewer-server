using System.Net;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using Newtonsoft.Json;
using RichardSzalay.MockHttp;
using SpaceXLaunchViewer.Core.QueryModels;
using SpaceXLaunchViewer.Core.ResponseModels;
using SpaceXLaunchViewer.Infrastructure.Services;

namespace SpaceXLaunchViewer.UnitTests;
public partial class SpaceXApiClientTests
{
    [Fact]
    public async Task GetUpcomingLaunchesAsync_InvalidQuery_ThrowsException()
    {
        // Arrange
        var query = new LaunchQuery(0);

        var expectedLaunches = GetMockLaunches()
            .Where(x => x.Upcoming is true)
            .ToList();

        _httpMockMessageHandler
            .When("https://api.spacex.com/v3/launches/upcoming?offset=0&limit=10")
            .Respond(HttpStatusCode.OK, new StringContent(
                JsonConvert.SerializeObject(expectedLaunches)));

        using var httpClient = new HttpClient(_httpMockMessageHandler)
        {
            BaseAddress = new Uri("https://api.spacex.com/v3/")
        };

        _httpClientFactoryMock
            .Setup(f => f.CreateClient(It.IsAny<string>()))
            .Returns(httpClient);

        _launchQueryValidatorMock
            .Setup(v => v.ValidateAsync(
                It.IsAny<LaunchQuery>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ValidationResult(
                new List<ValidationFailure>
                {
                    new ValidationFailure(
                        nameof(query.PageNumber),
                        "Page number must be greater than zero")
                }));

        var spaceXLaunchService = new SpaceXApiClient(
            _httpClientFactoryMock.Object,
            _launchQueryValidatorMock.Object);

        // Act
        var result = await spaceXLaunchService.GetUpcomingLaunchesAsync(query);

        // Assert
        Assert.False(result.IsSuccess);
        _ = result.Match(
            records => records,
            exception =>
            {
                Assert.IsType<ValidationException>(exception);
                return Enumerable.Empty<Launch>();
            });
    }

    [Fact]
    public async Task GetUpcomingLaunchesAsync_ValidQuery_ReturnsLaunches()
    {
        // Arrange
        var query = new LaunchQuery(1);

        var expectedLaunches = GetMockLaunches()
            .Where(x => x.Upcoming is true)
            .ToList();

        _httpMockMessageHandler
            .When("https://api.spacex.com/v3/launches/upcoming?offset=0&limit=10")
            .Respond(HttpStatusCode.OK, new StringContent(JsonConvert.SerializeObject(expectedLaunches)));

        using var httpClient = new HttpClient(_httpMockMessageHandler)
        {
            BaseAddress = new Uri("https://api.spacex.com/v3/")
        };

        _httpClientFactoryMock
            .Setup(f => f.CreateClient(It.IsAny<string>()))
            .Returns(httpClient);

        _launchQueryValidatorMock
            .Setup(v => v.ValidateAsync(It.IsAny<LaunchQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ValidationResult());

        var spaceXLaunchService = new SpaceXApiClient(
            _httpClientFactoryMock.Object,
            _launchQueryValidatorMock.Object);

        // Act
        var result = await spaceXLaunchService.GetUpcomingLaunchesAsync(query);

        // Assert
        var launches = result.Match(records => records, ex => Enumerable.Empty<Launch>());

        Assert.NotNull(launches);
        Assert.Equal(expectedLaunches.Count, launches.Count());
        Assert.Contains(launches, item => item.MissionName == "Mission Mars");
    }
}
