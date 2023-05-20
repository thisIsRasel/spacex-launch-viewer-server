using Newtonsoft.Json;

namespace SpaceXLaunchViewer.Core.ResponseModels;

public sealed class LaunchFailureDetails
{
    [JsonProperty("time")]
    public long? Time { get; set; }

    [JsonProperty("altitude")]
    public object? Altitude { get; set; }

    [JsonProperty("reason")]
    public string? Reason { get; set; }
}
