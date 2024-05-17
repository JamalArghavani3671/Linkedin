using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace BulkInsert.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext([NotNull] DbContextOptions options) : base(options)
    {

    }

    public DbSet<ElectricityBill> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ElectricityBillConfig());

        base.OnModelCreating(modelBuilder);
    }
}