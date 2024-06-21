using Newtonsoft.Json;
using System.Collections.Generic;


namespace ObjectsMapperBenchmark;

public partial class SpotifyAlbumDto_UsingList
{
    [JsonProperty("album_type")]
    public string AlbumType { get; set; }

    [JsonProperty("artists")]
    public List<ArtistDto> Artists { get; set; }

    [JsonProperty("available_markets")]
    public List<string> AvailableMarkets { get; set; }

    [JsonProperty("copyrights")]
    public List<CopyrightDto> Copyrights { get; set; }

    [JsonProperty("external_ids")]
    public ExternalIdsDto ExternalIds { get; set; }

    [JsonProperty("external_urls")]
    public ExternalUrlsDto ExternalUrls { get; set; }

    [JsonProperty("genres")]
    public List<object> Genres { get; set; }

    [JsonProperty("href")]
    public string Href { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("images")]
    public List<ImageDto> Images { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("popularity")]
    public long Popularity { get; set; }

    [JsonProperty("release_date")]
    public string ReleaseDate { get; set; }

    [JsonProperty("release_date_precision")]
    public string ReleaseDatePrecision { get; set; }

    [JsonProperty("tracks")]
    public TracksDto_UsingList Tracks { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("uri")]
    public string Uri { get; set; }
}


public class TracksDto_UsingList
{
    [JsonProperty("href")]
    public string Href { get; set; }

    [JsonProperty("items")]
    public List<ItemDto_UsingList> Items { get; set; }

    [JsonProperty("limit")]
    public long Limit { get; set; }

    [JsonProperty("next")]
    public object Next { get; set; }

    [JsonProperty("offset")]
    public long Offset { get; set; }

    [JsonProperty("previous")]
    public object Previous { get; set; }

    [JsonProperty("total")]
    public long Total { get; set; }
}

public class ItemDto_UsingList
{
    [JsonProperty("artists")]
    public List<ArtistDto> Artists { get; set; }

    [JsonProperty("available_markets")]
    public List<string> AvailableMarkets { get; set; }

    [JsonProperty("disc_number")]
    public long DiscNumber { get; set; }

    [JsonProperty("duration_ms")]
    public long DurationMs { get; set; }

    [JsonProperty("explicit")]
    public bool Explicit { get; set; }

    [JsonProperty("external_urls")]
    public ExternalUrlsDto ExternalUrls { get; set; }

    [JsonProperty("href")]
    public string Href { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("preview_url")]
    public string PreviewUrl { get; set; }

    [JsonProperty("track_number")]
    public long TrackNumber { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("uri")]
    public string Uri { get; set; }
}


public partial class SpotifyAlbumDto_UsingList
{
    public static SpotifyAlbumDto_UsingList FromJson(string json)
    {
        return JsonConvert.DeserializeObject<SpotifyAlbumDto_UsingList>(json, Converter.Settings);
    }
}