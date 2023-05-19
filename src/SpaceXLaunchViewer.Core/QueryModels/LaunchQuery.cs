namespace SpaceXLaunchViewer.Core.QueryModels;
public sealed class LaunchQuery
{
    public LaunchQuery(int pageNumber)
    {
        PageNumber = pageNumber;
    }

    public int PageNumber { get; init; }
}
