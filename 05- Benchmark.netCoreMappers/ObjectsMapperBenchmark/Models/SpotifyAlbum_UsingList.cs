using System.Collections.Generic;

namespace ObjectsMapperBenchmark;

public class SpotifyAlbum_UsingList
{
    public string AlbumType { get; set; }
    public List<Artist> Artists { get; set; }
    public List<string> AvailableMarkets { get; set; }
    public List<Copyright> Copyrights { get; set; }
    public ExternalIds ExternalIds { get; set; }
    public ExternalUrls ExternalUrls { get; set; }
    public List<object> Genres { get; set; }
    public string Href { get; set; }
    public string Id { get; set; }
    public List<Image> Images { get; set; }
    public string Name { get; set; }
    public long Popularity { get; set; }
    public string ReleaseDate { get; set; }
    public string ReleaseDatePrecision { get; set; }
    public Tracks_UsingList Tracks { get; set; }
    public string Type { get; set; }
    public string Uri { get; set; }
}

public class Tracks_UsingList
{
    public string Href { get; set; }
    public List<Item_UsingList> Items { get; set; }
    public long Limit { get; set; }
    public object Next { get; set; }
    public long Offset { get; set; }
    public object Previous { get; set; }
    public long Total { get; set; }
}

public class Item_UsingList
{
    public List<Artist> Artists { get; set; }
    public List<string> AvailableMarkets { get; set; }
    public long DiscNumber { get; set; }
    public long DurationMs { get; set; }
    public bool Explicit { get; set; }
    public ExternalUrls ExternalUrls { get; set; }
    public string Href { get; set; }
    public string Id { get; set; }
    public string Name { get; set; }
    public string PreviewUrl { get; set; }
    public long TrackNumber { get; set; }
    public string Type { get; set; }
    public string Uri { get; set; }
}