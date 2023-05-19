using System.ComponentModel.DataAnnotations;

namespace SpaceXLaunchViewer.Infrastructure.Settings;
public sealed class SpaceXOptions
{
    public const string SpaceX = "SpaceX";

    [Url]
    public string BaseUrl { get; init; } = string.Empty;
}
