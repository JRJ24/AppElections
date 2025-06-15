

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sadvo.Domain.Entities.Configuration;

namespace Sadvo.Persistence.EntityConfigurationsORM
{
    public class AliancePoliticalConfiguration : IEntityTypeConfiguration<AliancePolitical>
    {
        public void Configure(EntityTypeBuilder<AliancePolitical> builder) 
        {
            builder.ToTable("AliancePolitical");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_Aliance");

            builder.Property(c => c.NamePartyPolitcalSend)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Name_PartyPolitical_Send");

            builder.Property(c => c.NamePartyPolitcalReceived)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Name_PartyPolitical_Recived");

            builder.Property(c => c.isActive)
                .IsRequired()
                .HasColumnType("bit")
                .HasDefaultValue(true)
                .HasColumnName("Aliance_Active");
        }
    }
}
