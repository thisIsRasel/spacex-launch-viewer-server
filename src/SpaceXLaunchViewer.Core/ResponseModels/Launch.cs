using Newtonsoft.Json;

namespace SpaceXLaunchViewer.Core.ResponseModels;
public sealed class Launch
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

    [JsonProperty("launch_date_utc")]
    public DateTimeOffset? LaunchDateUtc { get; set; }

    [JsonProperty("launch_date_local")]
    public DateTimeOffset? LaunchDateLocal { get; set; }

    [JsonProperty("is_tentative")]
    public bool IsTentative { get; set; }

    [JsonProperty("launch_window")]
    public long? LaunchWindow { get; set; }

    [JsonProperty("launch_site")]
    public LaunchSite? LaunchSite { get; set; }

    [JsonProperty("launch_success")]
    public bool? LaunchSuccess { get; set; }

    [JsonProperty("details")]
    public string? Details { get; set; }
}
