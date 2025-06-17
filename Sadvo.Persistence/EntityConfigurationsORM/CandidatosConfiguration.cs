

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sadvo.Domain.Entities.Configuration;

namespace Sadvo.Persistence.EntityConfigurationsORM
{
    public class CandidatosConfiguration : IEntityTypeConfiguration<Candidatos>
    {
        public void Configure(EntityTypeBuilder<Candidatos> builder) 
        {
            builder.ToTable(nameof(Candidatos));
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Name");

            builder.Property(x => x.lastname)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("LastName");

            builder.Property(x => x.foto)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Foto");

            builder.Property(x => x.ElectionID)
                .IsRequired();

            builder.Property(x => x.isAssocciate)
                .IsRequired()
                .HasColumnType("bit")
                .HasDefaultValue(false);

            builder.Property(x => x.Description)
                .HasColumnName("Description");

            builder.Property(x => x.isActive)
                .IsRequired()
                .HasColumnType("bit")
                .HasDefaultValue(true);
        }
    }
}
