using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulkInsert.Context;

public class ElectricityBillConfig : IEntityTypeConfiguration<ElectricityBill>
{
    public void Configure(EntityTypeBuilder<ElectricityBill> builder)
    {
        builder.ToTable("ElectricityBills");

        builder.HasKey(d => d.BillId);

        builder.Property(d => d.BillId).UseIdentityColumn();

        builder.Property(d => d.TotalUsageKWh).HasColumnType("decimal(18,3)");
    }
}
