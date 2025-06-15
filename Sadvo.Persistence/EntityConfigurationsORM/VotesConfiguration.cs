

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sadvo.Domain.Entities.Configuration;
using Sadvo.Domain.Entities.Elections;
using Sadvo.Domain.Entities.ElectionsVotes.Citizen;

namespace Sadvo.Persistence.EntityConfigurationsORM
{
    public class VotesConfiguration : IEntityTypeConfiguration<Votes>
    {
        public void Configure(EntityTypeBuilder<Votes> builder)
        {
            builder.ToTable(nameof(Votes));
            builder.HasKey(v => v.ID);
            builder.HasAlternateKey(v => v.VoteNumber)
                .HasName("UQ_VOTENUMBER");
            builder.HasAlternateKey(v => v.citizensID)
                .HasName("UQ_CitizensID");
            builder.HasAlternateKey(v => v.siglasPartyPolitical)
             .HasName("UQ_SIGLASPARTYPOLITICAL");

            builder.Property(v => v.ID)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(v => v.VoteNumber)
                .IsRequired();

            builder.Property(v => v.citizensID)
                .IsRequired();

            builder.Property(v => v.citizensName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(v => v.siglasPartyPolitical)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(v => v.candidatosName)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(c => c.citizens)
                .WithOne(v => v.votes)
                .HasPrincipalKey<Votes>(v => v.citizensID)
                .HasForeignKey<Citizens>(c => c.Id)
                .HasConstraintName("FK_CITIZENDSID");

            builder.HasMany<PartyPolitical>(pl => pl.partyPoliticals)
                .WithOne(v => v.votes)
                .HasPrincipalKey(v => v.siglasPartyPolitical)
                .HasForeignKey(pl => pl.siglasPartyPolitical)
                .HasConstraintName("FK_SIGLASPARTYPOLITICAL");


        }
    }
}
