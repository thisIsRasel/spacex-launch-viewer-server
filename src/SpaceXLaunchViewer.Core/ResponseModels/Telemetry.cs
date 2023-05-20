using Newtonsoft.Json;

namespace SpaceXLaunchViewer.Core.ResponseModels;

public sealed class Telemetry
{
    [JsonProperty("flight_club")]
    public object? FlightClub { get; set; }
}
