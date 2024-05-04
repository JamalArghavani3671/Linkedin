using DatabaseSharding.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace DatabaseSharding.Context;

public class LinkedinDbContext : DbContext
{
    public LinkedinDbContext([NotNull] DbContextOptions options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserEntityConfig());

        base.OnModelCreating(modelBuilder);
    }
}
