using Newtonsoft.Json;

namespace SpaceXLaunchViewer.Core.ResponseModels;

public sealed class Fairings
{
    [JsonProperty("reused")]
    public bool? Reused { get; set; }

    [JsonProperty("recovery_attempt")]
    public bool? RecoveryAttempt { get; set; }

    [JsonProperty("recovered")]
    public bool? Recovered { get; set; }

    [JsonProperty("ship")]
    public object? Ship { get; set; }
}
