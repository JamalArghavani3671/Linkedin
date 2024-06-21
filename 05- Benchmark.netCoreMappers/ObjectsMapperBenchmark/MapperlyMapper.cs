using Riok.Mapperly.Abstractions;

namespace ObjectsMapperBenchmark;

[Mapper]
public partial class MapperlyMapper
{
    public partial SpotifyAlbum_UsingArray MapUsingArray(SpotifyAlbumDto_UsingArray spotifyAlbumDto);
    public partial SpotifyAlbum_UsingList MapUsingList(SpotifyAlbumDto_UsingList spotifyAlbumDto);
}