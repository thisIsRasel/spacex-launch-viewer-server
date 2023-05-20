using Newtonsoft.Json;

namespace SpaceXLaunchViewer.Core.ResponseModels;

public sealed class Payload
{
    [JsonProperty("payload_id")]
    public string? PayloadId { get; set; }

    [JsonProperty("norad_id")]
    public object[]? NoradId { get; set; }

    [JsonProperty("reused")]
    public bool Reused { get; set; }

    [JsonProperty("customers")]
    public string[]? Customers { get; set; }

    [JsonProperty("nationality")]
    public string? Nationality { get; set; }

    [JsonProperty("manufacturer")]
    public string? Manufacturer { get; set; }

    [JsonProperty("payload_type")]
    public string? PayloadType { get; set; }

    [JsonProperty("payload_mass_kg")]
    public long? PayloadMassKg { get; set; }

    [JsonProperty("payload_mass_lbs")]
    public long? PayloadMassLbs { get; set; }

    [JsonProperty("orbit")]
    public string? Orbit { get; set; }

    [JsonProperty("orbit_params")]
    public OrbitParams? OrbitParams { get; set; }
}
