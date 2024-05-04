
using DatabaseSharding.Context;
using DatabaseSharding.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DatabaseSharding;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //builder.Services.RegisterServices(builder.Configuration);


        #region Serevice Registration

        var shards = builder.Configuration?
            .GetSection("ConnectionStrings:ShardsConnectionString")?
            .Get<List<ShardConnectionString>>()?.ToList();
        var keys = shards.Select(d => d.ShardName).ToList();

        foreach (var shard in shards)
        {
            builder.Services.AddKeyedScoped
                (shard.ShardName, (serviceProvider, cnn) => new LinkedinDbContext(
                    new DbContextOptionsBuilder()
                    .UseSqlServer(shard.ConnectionString).Options)
                );

            builder.Services.AddKeyedScoped<IUserRepository>
                (shard.ShardName, (serviceProvider, cnn) =>
                {
                    var context = serviceProvider
                        .GetRequiredKeyedService<LinkedinDbContext>(shard.ShardName);
                    return new UserRepository(context);
                });
        }

        builder.Services.AddScoped<IDictionary<string, IUserRepository>>(p => keys
            .ToDictionary(k => k, k => p.GetRequiredKeyedService<IUserRepository>(k)));


        builder.Services.AddScoped<IDictionary<string, LinkedinDbContext>>(p => keys
            .ToDictionary(k => k, k => p.GetRequiredKeyedService<LinkedinDbContext>(k)));


        #endregion


        builder.Services.MigrateDatabase();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
