using Microsoft.AspNetCore.Mvc;
using SpaceXLaunchViewer.Core.Interfaces;
using SpaceXLaunchViewer.Core.QueryModels;
using SpaceXLaunchViewer.WebApi.Extensions;

namespace SpaceXLaunchViewer.WebApi.Controllers;
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public sealed class SpaceXController : ControllerBase
{
    private readonly ILogger<SpaceXController> _logger;
    private readonly ISpaceXApiClient _spaceXApiClient;

    public SpaceXController(
        ILogger<SpaceXController> logger,
        ISpaceXApiClient spaceXApiClient)
    {
        _logger = logger;
        _spaceXApiClient = spaceXApiClient;
    }

    [HttpGet("Launches/Past")]
    public async Task<IActionResult> GetPastLaunchesAsync(
        [FromQuery] int pageNumber)
    {
        _logger.LogInformation("Getting SpaceX past launches for page {PageNumber}", pageNumber);

        var query = new LaunchQuery(pageNumber);

        var result = await _spaceXApiClient.GetPastLaunchesAsync(query);

        return result.ToOk();
    }

    [HttpGet("Launches/Upcoming")]
    public async Task<IActionResult> GetUpcomingLaunchesAsync(
        [FromQuery] int pageNumber)
    {
        _logger.LogInformation("Getting SpaceX upcoming launches for page {PageNumber}", pageNumber);

        var query = new LaunchQuery(pageNumber);

        var result = await _spaceXApiClient.GetUpcomingLaunchesAsync(query);

        return result.ToOk();
    }
}
