using Newtonsoft.Json;

namespace SpaceXLaunchViewer.Core.ResponseModels;

public sealed class FirstStage
{
    [JsonProperty("cores")]
    public Core[]? Cores { get; set; }
}
