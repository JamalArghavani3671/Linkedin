using DatabaseSharding.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseSharding.Context;

public class UserEntityConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.Property(d => d.Id).UseIdentityColumn();

        builder.Property(d => d.FirstName).IsRequired().HasMaxLength(50).IsUnicode(true);

        builder.Property(d => d.LastName).IsRequired().HasMaxLength(50).IsUnicode(true);

        builder.Property(d => d.About).IsRequired().HasMaxLength(200).IsUnicode(true);
    }
}