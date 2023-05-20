namespace SpaceXLaunchViewer.Core.QueryModels;
public sealed class LaunchDetailQuery
{
    public LaunchDetailQuery(int flightNumber)
    {
        FlightNumber = flightNumber;
    }

    public int FlightNumber { get; init; }
}
