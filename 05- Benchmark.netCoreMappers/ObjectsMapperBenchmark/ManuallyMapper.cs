using System.Collections.Generic;
using System.Linq;

namespace ObjectsMapperBenchmark;

public static class ManuallyMapper
{
    public static SpotifyAlbum_UsingArray MapUsingArraySelect(this SpotifyAlbumDto_UsingArray spotifyAlbumDto)
    {
        return new SpotifyAlbum_UsingArray()
        {
            AlbumType = spotifyAlbumDto.AlbumType,
            Artists = spotifyAlbumDto.Artists.Select(spotifyAlbumDtoArtist => new Artist()
            {
                ExternalUrls = new ExternalUrls()
                {
                    Spotify = spotifyAlbumDtoArtist.ExternalUrls.Spotify
                },
                Href = spotifyAlbumDtoArtist.Href,
                Id = spotifyAlbumDtoArtist.Id,
                Name = spotifyAlbumDtoArtist.Name,
                Type = spotifyAlbumDtoArtist.Type,
                Uri = spotifyAlbumDtoArtist.Uri
            }).ToArray(),
            AvailableMarkets = spotifyAlbumDto.AvailableMarkets,
            Copyrights = spotifyAlbumDto.Copyrights.Select(spotifyAlbumDtoCopyright => new Copyright()
            {
                Text = spotifyAlbumDtoCopyright.Text,
                Type = spotifyAlbumDtoCopyright.Type
            }).ToArray(),
            ExternalIds = new ExternalIds()
            {
                Upc = spotifyAlbumDto.ExternalIds.Upc
            },
            ExternalUrls = new ExternalUrls()
            {
                Spotify = spotifyAlbumDto.ExternalUrls.Spotify
            },
            Genres = spotifyAlbumDto.Genres,
            Href = spotifyAlbumDto.Href,
            Id = spotifyAlbumDto.Id,
            Images = spotifyAlbumDto.Images.Select(spotifyAlbumDtoImage => new Image()
            {
                Height = spotifyAlbumDtoImage.Height,
                Url = spotifyAlbumDtoImage.Url,
                Width = spotifyAlbumDtoImage.Width
            }).ToArray(),
            Name = spotifyAlbumDto.Name,
            Popularity = spotifyAlbumDto.Popularity,
            ReleaseDate = spotifyAlbumDto.ReleaseDate,
            ReleaseDatePrecision = spotifyAlbumDto.ReleaseDatePrecision,
            Tracks = new Tracks_UsingArray()
            {
                Href = spotifyAlbumDto.Tracks.Href,
                Items = spotifyAlbumDto.Tracks.Items.Select(spotifyAlbumDtoTracksItem => new Item_UsingArray()
                {
                    Artists = spotifyAlbumDtoTracksItem.Artists.Select(spotifyAlbumDtoTracksItemArtist => new Artist()
                    {
                        ExternalUrls = new ExternalUrls()
                        {
                            Spotify = spotifyAlbumDtoTracksItemArtist.ExternalUrls.Spotify
                        },
                        Href = spotifyAlbumDtoTracksItemArtist.Href,
                        Id = spotifyAlbumDtoTracksItemArtist.Id,
                        Name = spotifyAlbumDtoTracksItemArtist.Name,
                        Type = spotifyAlbumDtoTracksItemArtist.Type,
                        Uri = spotifyAlbumDtoTracksItemArtist.Uri
                    }).ToArray(),
                    AvailableMarkets = spotifyAlbumDtoTracksItem.AvailableMarkets,
                    DiscNumber = spotifyAlbumDtoTracksItem.DiscNumber,
                    DurationMs = spotifyAlbumDtoTracksItem.DurationMs,
                    Explicit = spotifyAlbumDtoTracksItem.Explicit,
                    ExternalUrls = new ExternalUrls()
                    {
                        Spotify = spotifyAlbumDtoTracksItem.ExternalUrls.Spotify
                    },
                    Href = spotifyAlbumDtoTracksItem.Href,
                    Id = spotifyAlbumDtoTracksItem.Id,
                    Name = spotifyAlbumDtoTracksItem.Name,
                    PreviewUrl = spotifyAlbumDtoTracksItem.PreviewUrl,
                    TrackNumber = spotifyAlbumDtoTracksItem.TrackNumber,
                    Type = spotifyAlbumDtoTracksItem.Type,
                    Uri = spotifyAlbumDtoTracksItem.Uri
                }).ToArray(),
                Limit = spotifyAlbumDto.Tracks.Limit,
                Next = spotifyAlbumDto.Tracks.Next,
                Offset = spotifyAlbumDto.Tracks.Offset,
                Previous = spotifyAlbumDto.Tracks.Previous,
                Total = spotifyAlbumDto.Tracks.Total
            },
            Type = spotifyAlbumDto.Type,
            Uri = spotifyAlbumDto.Uri
        };
    }
    public static SpotifyAlbum_UsingList MapUsingListSelect(this SpotifyAlbumDto_UsingList spotifyAlbumDto)
    {
        return new SpotifyAlbum_UsingList()
        {
            AlbumType = spotifyAlbumDto.AlbumType,
            Artists = spotifyAlbumDto.Artists.Select(spotifyAlbumDtoArtist => new Artist()
            {
                ExternalUrls = new ExternalUrls()
                {
                    Spotify = spotifyAlbumDtoArtist.ExternalUrls.Spotify
                },
                Href = spotifyAlbumDtoArtist.Href,
                Id = spotifyAlbumDtoArtist.Id,
                Name = spotifyAlbumDtoArtist.Name,
                Type = spotifyAlbumDtoArtist.Type,
                Uri = spotifyAlbumDtoArtist.Uri
            }).ToList(),
            AvailableMarkets = spotifyAlbumDto.AvailableMarkets,
            Copyrights = spotifyAlbumDto.Copyrights.Select(spotifyAlbumDtoCopyright => new Copyright()
            {
                Text = spotifyAlbumDtoCopyright.Text,
                Type = spotifyAlbumDtoCopyright.Type
            }).ToList(),
            ExternalIds = new ExternalIds()
            {
                Upc = spotifyAlbumDto.ExternalIds.Upc
            },
            ExternalUrls = new ExternalUrls()
            {
                Spotify = spotifyAlbumDto.ExternalUrls.Spotify
            },
            Genres = spotifyAlbumDto.Genres,
            Href = spotifyAlbumDto.Href,
            Id = spotifyAlbumDto.Id,
            Images = spotifyAlbumDto.Images.Select(spotifyAlbumDtoImage => new Image()
            {
                Height = spotifyAlbumDtoImage.Height,
                Url = spotifyAlbumDtoImage.Url,
                Width = spotifyAlbumDtoImage.Width
            }).ToList(),
            Name = spotifyAlbumDto.Name,
            Popularity = spotifyAlbumDto.Popularity,
            ReleaseDate = spotifyAlbumDto.ReleaseDate,
            ReleaseDatePrecision = spotifyAlbumDto.ReleaseDatePrecision,
            Tracks = new Tracks_UsingList()
            {
                Href = spotifyAlbumDto.Tracks.Href,
                Items = spotifyAlbumDto.Tracks.Items.Select(spotifyAlbumDtoTracksItem => new Item_UsingList()
                {
                    Artists = spotifyAlbumDtoTracksItem.Artists.Select(spotifyAlbumDtoTracksItemArtist => new Artist()
                    {
                        ExternalUrls = new ExternalUrls()
                        {
                            Spotify = spotifyAlbumDtoTracksItemArtist.ExternalUrls.Spotify
                        },
                        Href = spotifyAlbumDtoTracksItemArtist.Href,
                        Id = spotifyAlbumDtoTracksItemArtist.Id,
                        Name = spotifyAlbumDtoTracksItemArtist.Name,
                        Type = spotifyAlbumDtoTracksItemArtist.Type,
                        Uri = spotifyAlbumDtoTracksItemArtist.Uri
                    }).ToList(),
                    AvailableMarkets = spotifyAlbumDtoTracksItem.AvailableMarkets,
                    DiscNumber = spotifyAlbumDtoTracksItem.DiscNumber,
                    DurationMs = spotifyAlbumDtoTracksItem.DurationMs,
                    Explicit = spotifyAlbumDtoTracksItem.Explicit,
                    ExternalUrls = new ExternalUrls()
                    {
                        Spotify = spotifyAlbumDtoTracksItem.ExternalUrls.Spotify
                    },
                    Href = spotifyAlbumDtoTracksItem.Href,
                    Id = spotifyAlbumDtoTracksItem.Id,
                    Name = spotifyAlbumDtoTracksItem.Name,
                    PreviewUrl = spotifyAlbumDtoTracksItem.PreviewUrl,
                    TrackNumber = spotifyAlbumDtoTracksItem.TrackNumber,
                    Type = spotifyAlbumDtoTracksItem.Type,
                    Uri = spotifyAlbumDtoTracksItem.Uri
                }).ToList(),
                Limit = spotifyAlbumDto.Tracks.Limit,
                Next = spotifyAlbumDto.Tracks.Next,
                Offset = spotifyAlbumDto.Tracks.Offset,
                Previous = spotifyAlbumDto.Tracks.Previous,
                Total = spotifyAlbumDto.Tracks.Total
            },
            Type = spotifyAlbumDto.Type,
            Uri = spotifyAlbumDto.Uri
        };
    }


    public static SpotifyAlbum_UsingArray? MapUsingArrayFor(this SpotifyAlbumDto_UsingArray? spotifyAlbumDto)
    {
        if (spotifyAlbumDto == null)
            return default;
        var target = new SpotifyAlbum_UsingArray();
        if (spotifyAlbumDto.Artists != null)
        {
            target.Artists = MapToArtistArray(spotifyAlbumDto.Artists);
        }
        else
        {
            target.Artists = null;
        }
        if (spotifyAlbumDto.Copyrights != null)
        {
            target.Copyrights = MapToCopyrightArray(spotifyAlbumDto.Copyrights);
        }
        else
        {
            target.Copyrights = null;
        }
        if (spotifyAlbumDto.ExternalIds != null)
        {
            target.ExternalIds = MapToExternalIds(spotifyAlbumDto.ExternalIds);
        }
        else
        {
            target.ExternalIds = null;
        }
        if (spotifyAlbumDto.ExternalUrls != null)
        {
            target.ExternalUrls = MapToExternalUrls(spotifyAlbumDto.ExternalUrls);
        }
        else
        {
            target.ExternalUrls = null;
        }
        if (spotifyAlbumDto.Images != null)
        {
            target.Images = MapToImageArray(spotifyAlbumDto.Images);
        }
        else
        {
            target.Images = null;
        }
        if (spotifyAlbumDto.Tracks != null)
        {
            target.Tracks = MapToTracks_UsingArray(spotifyAlbumDto.Tracks);
        }
        else
        {
            target.Tracks = null;
        }
        target.AlbumType = spotifyAlbumDto.AlbumType;
        target.AvailableMarkets = spotifyAlbumDto.AvailableMarkets;
        target.Genres = spotifyAlbumDto.Genres;
        target.Href = spotifyAlbumDto.Href;
        target.Id = spotifyAlbumDto.Id;
        target.Name = spotifyAlbumDto.Name;
        target.Popularity = spotifyAlbumDto.Popularity;
        target.ReleaseDate = spotifyAlbumDto.ReleaseDate;
        target.ReleaseDatePrecision = spotifyAlbumDto.ReleaseDatePrecision;
        target.Type = spotifyAlbumDto.Type;
        target.Uri = spotifyAlbumDto.Uri;
        return target;
    }


    public static SpotifyAlbum_UsingList? MapUsingListFor(this SpotifyAlbumDto_UsingList? spotifyAlbumDto)
    {
        if (spotifyAlbumDto == null)
            return default;
        var target = new SpotifyAlbum_UsingList();
        if (spotifyAlbumDto.Artists != null)
        {
            target.Artists = MapToListOfArtist(spotifyAlbumDto.Artists);
        }
        else
        {
            target.Artists = null;
        }
        if (spotifyAlbumDto.Copyrights != null)
        {
            target.Copyrights = MapToListOfCopyright(spotifyAlbumDto.Copyrights);
        }
        else
        {
            target.Copyrights = null;
        }
        if (spotifyAlbumDto.ExternalIds != null)
        {
            target.ExternalIds = MapToExternalIds(spotifyAlbumDto.ExternalIds);
        }
        else
        {
            target.ExternalIds = null;
        }
        if (spotifyAlbumDto.ExternalUrls != null)
        {
            target.ExternalUrls = MapToExternalUrls(spotifyAlbumDto.ExternalUrls);
        }
        else
        {
            target.ExternalUrls = null;
        }
        if (spotifyAlbumDto.Images != null)
        {
            target.Images = MapToListOfImage(spotifyAlbumDto.Images);
        }
        else
        {
            target.Images = null;
        }
        if (spotifyAlbumDto.Tracks != null)
        {
            target.Tracks = MapToTracks_UsingList(spotifyAlbumDto.Tracks);
        }
        else
        {
            target.Tracks = null;
        }
        target.AlbumType = spotifyAlbumDto.AlbumType;
        target.AvailableMarkets = spotifyAlbumDto.AvailableMarkets;
        target.Genres = spotifyAlbumDto.Genres;
        target.Href = spotifyAlbumDto.Href;
        target.Id = spotifyAlbumDto.Id;
        target.Name = spotifyAlbumDto.Name;
        target.Popularity = spotifyAlbumDto.Popularity;
        target.ReleaseDate = spotifyAlbumDto.ReleaseDate;
        target.ReleaseDatePrecision = spotifyAlbumDto.ReleaseDatePrecision;
        target.Type = spotifyAlbumDto.Type;
        target.Uri = spotifyAlbumDto.Uri;
        return target;
    }


    private static Artist? MapToArtist(ArtistDto? source)
    {
        if (source == null)
            return default;
        var target = new Artist();
        if (source.ExternalUrls != null)
        {
            target.ExternalUrls = MapToExternalUrls(source.ExternalUrls);
        }
        else
        {
            target.ExternalUrls = null;
        }
        target.Href = source.Href;
        target.Id = source.Id;
        target.Name = source.Name;
        target.Type = source.Type;
        target.Uri = source.Uri;
        return target;
    }


    private static Artist?[] MapToArtistArray(ArtistDto?[] source)
    {
        var target = new Artist?[source.Length];
        for (var i = 0; i < source.Length; i++)
        {
            target[i] = MapToArtist(source[i]);
        }
        return target;
    }


    private static Copyright? MapToCopyright(CopyrightDto? source)
    {
        if (source == null)
            return default;
        var target = new Copyright();
        target.Text = source.Text;
        target.Type = source.Type;
        return target;
    }


    private static Copyright?[] MapToCopyrightArray(CopyrightDto?[] source)
    {
        var target = new Copyright?[source.Length];
        for (var i = 0; i < source.Length; i++)
        {
            target[i] = MapToCopyright(source[i]);
        }
        return target;
    }


    private static ExternalIds MapToExternalIds(ExternalIdsDto source)
    {
        var target = new ExternalIds();
        target.Upc = source.Upc;
        return target;
    }


    private static ExternalUrls MapToExternalUrls(ExternalUrlsDto source)
    {
        var target = new ExternalUrls();
        target.Spotify = source.Spotify;
        return target;
    }


    private static Image? MapToImage(ImageDto? source)
    {
        if (source == null)
            return default;
        var target = new Image();
        target.Height = source.Height;
        target.Url = source.Url;
        target.Width = source.Width;
        return target;
    }


    private static Image?[] MapToImageArray(ImageDto?[] source)
    {
        var target = new Image?[source.Length];
        for (var i = 0; i < source.Length; i++)
        {
            target[i] = MapToImage(source[i]);
        }
        return target;
    }


    private static Tracks_UsingArray MapToTracks_UsingArray(TracksDto_UsingArray source)
    {
        var target = new Tracks_UsingArray();
        if (source.Items != null)
        {
            target.Items = MapToItem_UsingArrayArray(source.Items);
        }
        else
        {
            target.Items = null;
        }
        if (source.Next != null)
        {
            target.Next = (object)source.Next;
        }
        else
        {
            target.Next = null;
        }
        if (source.Previous != null)
        {
            target.Previous = (object)source.Previous;
        }
        else
        {
            target.Previous = null;
        }
        target.Href = source.Href;
        target.Limit = source.Limit;
        target.Offset = source.Offset;
        target.Total = source.Total;
        return target;
    }


    private static List<Artist?> MapToListOfArtist(IReadOnlyCollection<ArtistDto?> source)
    {
        var target = new List<Artist?>(source.Count);
        foreach (var item in source)
        {
            target.Add(MapToArtist(item));
        }
        return target;
    }


    private static List<Copyright?> MapToListOfCopyright(IReadOnlyCollection<CopyrightDto?> source)
    {
        var target = new List<Copyright?>(source.Count);
        foreach (var item in source)
        {
            target.Add(MapToCopyright(item));
        }
        return target;
    }


    private static List<Image?> MapToListOfImage(IReadOnlyCollection<ImageDto?> source)
    {
        var target = new List<Image?>(source.Count);
        foreach (var item in source)
        {
            target.Add(MapToImage(item));
        }
        return target;
    }


    private static Tracks_UsingList MapToTracks_UsingList(TracksDto_UsingList source)
    {
        var target = new Tracks_UsingList();
        if (source.Items != null)
        {
            target.Items = MapToListOfItem_UsingList(source.Items);
        }
        else
        {
            target.Items = null;
        }
        if (source.Next != null)
        {
            target.Next = (object)source.Next;
        }
        else
        {
            target.Next = null;
        }
        if (source.Previous != null)
        {
            target.Previous = (object)source.Previous;
        }
        else
        {
            target.Previous = null;
        }
        target.Href = source.Href;
        target.Limit = source.Limit;
        target.Offset = source.Offset;
        target.Total = source.Total;
        return target;
    }


    private static Item_UsingArray? MapToItem_UsingArray(ItemDto_UsingArray? source)
    {
        if (source == null)
            return default;
        var target = new Item_UsingArray();
        if (source.Artists != null)
        {
            target.Artists = MapToArtistArray(source.Artists);
        }
        else
        {
            target.Artists = null;
        }
        if (source.ExternalUrls != null)
        {
            target.ExternalUrls = MapToExternalUrls(source.ExternalUrls);
        }
        else
        {
            target.ExternalUrls = null;
        }
        target.AvailableMarkets = source.AvailableMarkets;
        target.DiscNumber = source.DiscNumber;
        target.DurationMs = source.DurationMs;
        target.Explicit = source.Explicit;
        target.Href = source.Href;
        target.Id = source.Id;
        target.Name = source.Name;
        target.PreviewUrl = source.PreviewUrl;
        target.TrackNumber = source.TrackNumber;
        target.Type = source.Type;
        target.Uri = source.Uri;
        return target;
    }


    private static Item_UsingArray?[] MapToItem_UsingArrayArray(ItemDto_UsingArray?[] source)
    {
        var target = new Item_UsingArray?[source.Length];
        for (var i = 0; i < source.Length; i++)
        {
            target[i] = MapToItem_UsingArray(source[i]);
        }
        return target;
    }


    private static Item_UsingList? MapToItem_UsingList(ItemDto_UsingList? source)
    {
        if (source == null)
            return default;
        var target = new Item_UsingList();
        if (source.Artists != null)
        {
            target.Artists = MapToListOfArtist(source.Artists);
        }
        else
        {
            target.Artists = null;
        }
        if (source.ExternalUrls != null)
        {
            target.ExternalUrls = MapToExternalUrls(source.ExternalUrls);
        }
        else
        {
            target.ExternalUrls = null;
        }
        target.AvailableMarkets = source.AvailableMarkets;
        target.DiscNumber = source.DiscNumber;
        target.DurationMs = source.DurationMs;
        target.Explicit = source.Explicit;
        target.Href = source.Href;
        target.Id = source.Id;
        target.Name = source.Name;
        target.PreviewUrl = source.PreviewUrl;
        target.TrackNumber = source.TrackNumber;
        target.Type = source.Type;
        target.Uri = source.Uri;
        return target;
    }


    private static List<Item_UsingList?> MapToListOfItem_UsingList(IReadOnlyCollection<ItemDto_UsingList?> source)
    {
        var target = new List<Item_UsingList?>(source.Count);
        foreach (var item in source)
        {
            target.Add(MapToItem_UsingList(item));
        }
        return target;
    }
}
