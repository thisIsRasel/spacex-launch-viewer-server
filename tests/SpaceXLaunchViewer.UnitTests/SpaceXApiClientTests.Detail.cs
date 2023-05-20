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
    public async Task GetLaunchByFlightNumberAsync_InvalidQuery_ThrowsException()
    {
        // Arrange
        var flightNumber = 1;
        var query = new LaunchDetailQuery(flightNumber);

        var expectedLaunch = GetMockLaunchDetail();

        _httpMockMessageHandler
            .When($"https://api.spacex.com/v3/launches/{flightNumber}")
            .Respond(HttpStatusCode.OK, new StringContent(
                JsonConvert.SerializeObject(expectedLaunch)));

        using var httpClient = new HttpClient(_httpMockMessageHandler)
        {
            BaseAddress = new Uri("https://api.spacex.com/v3/")
        };

        _httpClientFactoryMock
            .Setup(f => f.CreateClient(It.IsAny<string>()))
            .Returns(httpClient);

        _launchDetailQueryValidatorMock
            .Setup(v => v.ValidateAsync(It.IsAny<LaunchDetailQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ValidationResult(
                new List<ValidationFailure>
                {
                    new ValidationFailure(
                        nameof(query.FlightNumber),
                        "Flight number must be greater than zero")
                }));

        var spaceXLaunchService = new SpaceXApiClient(
            _httpClientFactoryMock.Object,
            _launchQueryValidatorMock.Object,
            _launchDetailQueryValidatorMock.Object);

        // Act
        var result = await spaceXLaunchService.GetLaunchByFlightNumberAsync(query);

        // Assert
        Assert.False(result.IsSuccess);
        _ = result.Match(
           record => record,
           exception =>
           {
               Assert.IsType<ValidationException>(exception);
               return null;
           });
    }

    [Fact]
    public async Task GetLaunchByFlightNumberAsync_ValidQuery_ReturnsLaunchDetail()
    {
        // Arrange
        var flightNumber = 1;
        var query = new LaunchDetailQuery(flightNumber);

        var expectedLaunch = GetMockLaunchDetail();

        _httpMockMessageHandler
            .When($"https://api.spacex.com/v3/launches/{flightNumber}")
            .Respond(HttpStatusCode.OK, new StringContent(JsonConvert.SerializeObject(expectedLaunch)));

        using var httpClient = new HttpClient(_httpMockMessageHandler)
        {
            BaseAddress = new Uri("https://api.spacex.com/v3/")
        };

        _httpClientFactoryMock
            .Setup(f => f.CreateClient(It.IsAny<string>()))
            .Returns(httpClient);

        _launchDetailQueryValidatorMock
            .Setup(v => v.ValidateAsync(It.IsAny<LaunchDetailQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ValidationResult());

        var spaceXLaunchService = new SpaceXApiClient(
            _httpClientFactoryMock.Object,
            _launchQueryValidatorMock.Object,
            _launchDetailQueryValidatorMock.Object);

        // Act
        var result = await spaceXLaunchService.GetLaunchByFlightNumberAsync(query);

        // Assert
        var launch = result.Match(record => record, ex => null);

        Assert.NotNull(launch);
        Assert.Equal(expectedLaunch.FlightNumber, launch.FlightNumber);
    }

    private static LaunchDetail GetMockLaunchDetail()
    {
        return new LaunchDetail
        {
            FlightNumber = 1,
            MissionName = "Test Mission",
            Upcoming = false,
            LaunchSite = new LaunchSite
            {
                SiteId = "100",
                SiteName = "Test Site",
                SiteNameLong = "Test Site Long Name"
            },
            LaunchSuccess = true,
            Details = "This is a test detail for launch"
        };
    }
}
