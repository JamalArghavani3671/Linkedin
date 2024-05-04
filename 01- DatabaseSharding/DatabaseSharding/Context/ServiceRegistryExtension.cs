using DatabaseSharding.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DatabaseSharding.Context;

public static class ServiceRegistryExtension
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        var shards = configuration?.GetSection("ConnectionStrings:ShardsConnectionString")?
            .Get<List<ShardConnectionString>>()?.ToList();

        services.RegisterLinkedinDbContextForAllShards(shards);
        services.RegisterRepositoriesForAllShards(shards);

        return services;
    }

    public static IServiceCollection RegisterLinkedinDbContextForAllShards(this IServiceCollection services, List<ShardConnectionString> shards)
    {
        foreach (var shard in shards)
        {
            services.AddKeyedScoped(shard.ShardName,
                (serviceProvider, cnn) => new LinkedinDbContext(
                    new DbContextOptionsBuilder().UseSqlServer(shard.ConnectionString).Options));
        }

        var keys = shards.Select(d => d.ShardName).ToList();

        services.AddScoped<IDictionary<string, LinkedinDbContext>>(p => keys
            .ToDictionary(k => k, k => p.GetRequiredKeyedService<LinkedinDbContext>(k)));

        return services;
    }



    public static IServiceCollection RegisterRepositoriesForAllShards(this IServiceCollection services, List<ShardConnectionString> shards)
    {
        foreach (var shard in shards)
        {
            services.AddKeyedScoped<IUserRepository>(shard.ShardName,
                (serviceProvider, cnn) => { 
                    var context=serviceProvider.GetRequiredKeyedService<LinkedinDbContext>(shard.ShardName);
                    return new UserRepository(context);
                });
        }

        var keys = shards.Select(d => d.ShardName).ToList();

        services.AddScoped<IDictionary<string, IUserRepository>>(p => keys
            .ToDictionary(k => k, k => p.GetRequiredKeyedService<IUserRepository>(k)));

        return services;
    }
}