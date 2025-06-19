

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sadvo.Domain.Entities.Security;

namespace Sadvo.Persistence.EntityConfigurationsORM
{
    public class RolConfiguration : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            builder.ToTable(nameof(Roles));
            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => x.Name)
                .HasName("UQ_NAMEROL");

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("NameRol");

            builder.Property(x => x.Description);

            builder.Property(x => x.isActive)
                .IsRequired()
                .HasColumnType("bit")
                .HasDefaultValue(true);

        }
    }
}
