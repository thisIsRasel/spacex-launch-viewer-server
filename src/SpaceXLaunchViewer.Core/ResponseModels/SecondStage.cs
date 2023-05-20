using Newtonsoft.Json;

namespace SpaceXLaunchViewer.Core.ResponseModels;

public sealed class SecondStage
{
    [JsonProperty("block")]
    public long? Block { get; set; }

    [JsonProperty("payloads")]
    public Payload[]? Payloads { get; set; }
}
