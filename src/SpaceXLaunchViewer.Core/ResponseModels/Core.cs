using Newtonsoft.Json;

namespace SpaceXLaunchViewer.Core.ResponseModels;

public sealed class Core
{
    [JsonProperty("core_serial")]
    public string? CoreSerial { get; set; }

    [JsonProperty("flight")]
    public long? Flight { get; set; }

    [JsonProperty("block")]
    public object? Block { get; set; }

    [JsonProperty("gridfins")]
    public bool? Gridfins { get; set; }

    [JsonProperty("legs")]
    public bool? Legs { get; set; }

    [JsonProperty("reused")]
    public bool? Reused { get; set; }

    [JsonProperty("land_success")]
    public object? LandSuccess { get; set; }

    [JsonProperty("landing_intent")]
    public bool? LandingIntent { get; set; }

    [JsonProperty("landing_type")]
    public object? LandingType { get; set; }

    [JsonProperty("landing_vehicle")]
    public object? LandingVehicle { get; set; }
}
