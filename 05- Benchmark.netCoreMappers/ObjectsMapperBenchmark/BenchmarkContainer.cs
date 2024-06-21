using AutoMapper;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Mapster;
using System.IO;

namespace ObjectsMapperBenchmark;

[SimpleJob(BenchmarkDotNet.Engines.RunStrategy.Throughput)]
//[MemoryDiagnoser]
[KeepBenchmarkFiles(false)]
[Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
public class BenchmarkContainer
{
    private SpotifyAlbumDto_UsingArray _spotifyAlbumDto_UsingArray;
    private SpotifyAlbumDto_UsingList _spotifyAlbumDto_UsingList;
    private IMapper _autoMapper;
    private MapperlyMapper _mapperlyMapper;

    [GlobalSetup]
    public void Setup()
    {
        var json = File.ReadAllText("spotifyAlbum.json");
        _spotifyAlbumDto_UsingArray = SpotifyAlbumDto_UsingArray.FromJson(json);
        _spotifyAlbumDto_UsingList = SpotifyAlbumDto_UsingList.FromJson(json);

        //Automapper Configuration
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<SpotifyAlbumDto_UsingArray, SpotifyAlbum_UsingArray>();
            cfg.CreateMap<CopyrightDto, Copyright>();
            cfg.CreateMap<ArtistDto, Artist>();
            cfg.CreateMap<ExternalIdsDto, ExternalIds>();
            cfg.CreateMap<ExternalUrlsDto, ExternalUrls>();
            cfg.CreateMap<TracksDto_UsingArray, Tracks_UsingArray>();
            cfg.CreateMap<ImageDto, Image>();
            cfg.CreateMap<ItemDto_UsingArray, Item_UsingArray>();
            cfg.CreateMap<SpotifyAlbum_UsingArray, SpotifyAlbumDto_UsingArray>();
            cfg.CreateMap<Copyright, CopyrightDto>();
            cfg.CreateMap<Artist, ArtistDto>();
            cfg.CreateMap<ExternalIds, ExternalIdsDto>();
            cfg.CreateMap<ExternalUrls, ExternalUrlsDto>();
            cfg.CreateMap<Tracks_UsingArray, TracksDto_UsingArray>();
            cfg.CreateMap<Image, ImageDto>();
            cfg.CreateMap<Item_UsingArray, ItemDto_UsingArray>();


            cfg.CreateMap<SpotifyAlbumDto_UsingList, SpotifyAlbum_UsingList>();
            cfg.CreateMap<TracksDto_UsingList, Tracks_UsingList>();
            cfg.CreateMap<ItemDto_UsingList, Item_UsingList>();
            cfg.CreateMap<SpotifyAlbum_UsingList, SpotifyAlbumDto_UsingList>();
            cfg.CreateMap<Tracks_UsingList, TracksDto_UsingList>();
            cfg.CreateMap<Item_UsingList, ItemDto_UsingList>();
        });
        _autoMapper = mapperConfig.CreateMapper();

        // Mapperly
        _mapperlyMapper = new MapperlyMapper();

        //Mapster don't need configuration
    }

    [Benchmark]
    public void AutoMapperUsingArray()
    {
        _autoMapper.Map<SpotifyAlbum_UsingArray>(_spotifyAlbumDto_UsingArray);
    }

    [Benchmark]
    public void AutoMapperUsingList()
    {
        _autoMapper.Map<SpotifyAlbum_UsingList>(_spotifyAlbumDto_UsingList);
    }

    //[Benchmark]
    //public void ManualMappingUsingArraySelect()
    //{
    //    _spotifyAlbumDto_UsingArray.MapUsingArraySelect();
    //}

    [Benchmark]
    public void ManualMappingUsingArray()
    {
        _spotifyAlbumDto_UsingArray.MapUsingArrayFor();
    }

    //[Benchmark]
    //public void ManualMappingUsingListSelect()
    //{
    //    _spotifyAlbumDto_UsingList.MapUsingListSelect();
    //}

    [Benchmark]
    public void ManualMappingUsingList()
    {
        _spotifyAlbumDto_UsingList.MapUsingListFor();
    }

    [Benchmark]
    public void MapsterUsingArray()
    {
        _spotifyAlbumDto_UsingArray.Adapt<SpotifyAlbum_UsingArray>();
    }

    [Benchmark]
    public void MapsterUsingList()
    {
        _spotifyAlbumDto_UsingList.Adapt<SpotifyAlbum_UsingList>();
    }

    [Benchmark(Baseline =true)]
    public void MapperlyUsingArray()
    {
        _mapperlyMapper.MapUsingArray(_spotifyAlbumDto_UsingArray);
    }

    [Benchmark]
    public void MapperlyUsingList()
    {
        _mapperlyMapper.MapUsingList(_spotifyAlbumDto_UsingList);
    }
}
