

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sadvo.Domain.Entities.Configuration;

namespace Sadvo.Persistence.EntityConfigurationsORM
{
    public class PartyPoliticalConfiguration : IEntityTypeConfiguration<PartyPolitical>
    {
        public void Configure(EntityTypeBuilder<PartyPolitical> builder)
        {
            builder.ToTable(nameof(PartyPolitical));
            builder.HasKey(p => p.Id);
            builder.HasAlternateKey(p => p.siglasPartyPolitical);
            builder.HasIndex(p => p.siglasPartyPolitical)
                .IsUnique();

            builder.Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Description)
              .HasMaxLength(int.MaxValue);

            builder.Property(p => p.isActive)
                .IsRequired()
                .HasColumnType("bit")
                .HasDefaultValue(true);

            builder.Property(p => p.siglasPartyPolitical)
                .IsRequired()
                .HasMaxLength(10);



            builder.HasOne(p => p.leader)
                .WithOne(pl => pl.partyPolitical)
                .HasPrincipalKey<PartyPolitical>(p => p.siglasPartyPolitical)
                .HasForeignKey<PoliticalLeader>(pl => pl.siglasPartyPolitical)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(ap => ap.aliancePolitical)
                .WithMany(p => p.Politicals)
                .UsingEntity<Dictionary<string, object>>(
                    "PartyPoliticalAliance",
                    j => j.HasOne<AliancePolitical>()
                          .WithMany()
                          .HasForeignKey("AliancePoliticalId")
                          .OnDelete(DeleteBehavior.Cascade),
                    j => j.HasOne<PartyPolitical>()
                          .WithMany()
                          .HasForeignKey("PartyPoliticalId")
                          .OnDelete(DeleteBehavior.Cascade));
        }
    }
}
