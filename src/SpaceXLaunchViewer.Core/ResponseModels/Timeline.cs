using Newtonsoft.Json;

namespace SpaceXLaunchViewer.Core.ResponseModels;

public sealed class Timeline
{
    [JsonProperty("webcast_liftoff")]
    public long? WebcastLiftoff { get; set; }
}