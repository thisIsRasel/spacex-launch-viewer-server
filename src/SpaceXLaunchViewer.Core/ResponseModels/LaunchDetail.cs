using Newtonsoft.Json;

namespace SpaceXLaunchViewer.Core.ResponseModels;
public sealed class LaunchDetail
{
    [JsonProperty("flight_number")]
    public long FlightNumber { get; set; }

    [JsonProperty("mission_name")]
    public string? MissionName { get; set; }

    [JsonProperty("mission_id")]
    public object[]? MissionId { get; set; }

    [JsonProperty("upcoming")]
    public bool Upcoming { get; set; }

    [JsonProperty("launch_year")]
    public long? LaunchYear { get; set; }

    [JsonProperty("launch_date_unix")]
    public long? LaunchDateUnix { get; set; }

    [JsonProperty("launch_date_utc")]
    public DateTimeOffset? LaunchDateUtc { get; set; }

    [JsonProperty("launch_date_local")]
    public DateTimeOffset? LaunchDateLocal { get; set; }

    [JsonProperty("is_tentative")]
    public bool IsTentative { get; set; }

    [JsonProperty("tentative_max_precision")]
    public string? TentativeMaxPrecision { get; set; }

    [JsonProperty("tbd")]
    public bool Tbd { get; set; }

    [JsonProperty("launch_window")]
    public long? LaunchWindow { get; set; }

    [JsonProperty("rocket")]
    public Rocket? Rocket { get; set; }

    [JsonProperty("ships")]
    public object[]? Ships { get; set; }

    [JsonProperty("telemetry")]
    public Telemetry? Telemetry { get; set; }

    [JsonProperty("launch_site")]
    public LaunchSite? LaunchSite { get; set; }

    [JsonProperty("launch_success")]
    public bool? LaunchSuccess { get; set; }

    [JsonProperty("launch_failure_details")]
    public LaunchFailureDetails? LaunchFailureDetails { get; set; }

    [JsonProperty("links")]
    public Links? Links { get; set; }

    [JsonProperty("details")]
    public string? Details { get; set; }

    [JsonProperty("static_fire_date_utc")]
    public DateTimeOffset? StaticFireDateUtc { get; set; }

    [JsonProperty("static_fire_date_unix")]
    public long? StaticFireDateUnix { get; set; }

    [JsonProperty("timeline")]
    public Timeline? Timeline { get; set; }
}
