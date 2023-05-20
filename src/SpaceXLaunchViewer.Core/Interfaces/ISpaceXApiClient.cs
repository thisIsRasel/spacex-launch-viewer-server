using LanguageExt.Common;
using SpaceXLaunchViewer.Core.QueryModels;
using SpaceXLaunchViewer.Core.ResponseModels;

namespace SpaceXLaunchViewer.Core.Interfaces;
public interface ISpaceXApiClient
{
    Task<Result<LaunchDetail?>> GetLaunchByFlightNumberAsync(LaunchDetailQuery query);

    Task<Result<IEnumerable<Launch>?>> GetPastLaunchesAsync(LaunchQuery query);

    Task<Result<IEnumerable<Launch>?>> GetUpcomingLaunchesAsync(LaunchQuery query);
}
