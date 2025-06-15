

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sadvo.Domain.Entities.Configuration;

namespace Sadvo.Persistence.EntityConfigurationsORM
{
    public class ElectivePositionsConfiguration : IEntityTypeConfiguration<ElectivePositions>
    {
        public void Configure(EntityTypeBuilder<ElectivePositions> builder)
        {
            builder.ToTable(nameof(ElectivePositions));
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Description)
                .HasMaxLength(int.MaxValue);

            builder.Property(e => e.isActive)
                .IsRequired()
                .HasColumnType("bit")
                .HasDefaultValue(true);
        }
    }
}
