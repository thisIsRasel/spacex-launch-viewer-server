using Newtonsoft.Json;

namespace SpaceXLaunchViewer.Core.ResponseModels;

public sealed class Links
{
    [JsonProperty("mission_patch")]
    public Uri? MissionPatch { get; set; }

    [JsonProperty("mission_patch_small")]
    public Uri? MissionPatchSmall { get; set; }

    [JsonProperty("reddit_campaign")]
    public object? RedditCampaign { get; set; }

    [JsonProperty("reddit_launch")]
    public object? RedditLaunch { get; set; }

    [JsonProperty("reddit_recovery")]
    public object? RedditRecovery { get; set; }

    [JsonProperty("reddit_media")]
    public object? RedditMedia { get; set; }

    [JsonProperty("presskit")]
    public object? Presskit { get; set; }

    [JsonProperty("article_link")]
    public Uri? ArticleLink { get; set; }

    [JsonProperty("wikipedia")]
    public Uri? Wikipedia { get; set; }

    [JsonProperty("video_link")]
    public Uri? VideoLink { get; set; }

    [JsonProperty("youtube_id")]
    public string? YoutubeId { get; set; }

    [JsonProperty("flickr_images")]
    public object[]? FlickrImages { get; set; }
}
