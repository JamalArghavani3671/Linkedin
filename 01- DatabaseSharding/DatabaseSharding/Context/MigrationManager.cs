using Microsoft.EntityFrameworkCore;

namespace DatabaseSharding.Context;

public static class MigrationManager
{
    public static IServiceCollection MigrateDatabase(this IServiceCollection services)
    {
        using (var serviceProvider = services.BuildServiceProvider())
        {
            var allDbContext = serviceProvider.GetRequiredService<IDictionary<string, LinkedinDbContext>>();
            foreach (var context in allDbContext)
            {
                try
                {
                    context.Value.Database.Migrate();
                }
                catch (Exception ex)
                {
                    // log and handle exception
                }
            }
        }

        return services;
    }
}