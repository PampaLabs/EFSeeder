using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EFSeeder;

internal class DataSeederHistoryConfiguration : IEntityTypeConfiguration<DataSeederHistory>
{
    public void Configure(EntityTypeBuilder<DataSeederHistory> builder)
    {
        builder.HasKey(e => e.DataSeederId);

        builder.ToTable("__DataSeedersHistory");

        builder.Property(e => e.DataSeederId)
            .HasMaxLength(150);
    }
}