using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DatabaseSharding.Context;

public class LinkedinDbContextFactory : IDesignTimeDbContextFactory<LinkedinDbContext>
{
    public LinkedinDbContext CreateDbContext(string[] args)
    {
        var connectionString = "Data Source=.;Initial Catalog=LinkedinContext_Master;User ID=j.arghavani;password=sS@o83oo55762;Encrypt=False";

        var optionsBuilder = new DbContextOptionsBuilder<LinkedinDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new LinkedinDbContext(optionsBuilder.Options);
    }
}