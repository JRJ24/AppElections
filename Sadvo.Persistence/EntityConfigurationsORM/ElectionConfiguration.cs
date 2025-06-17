

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sadvo.Domain.Entities.Configuration;
using Sadvo.Domain.Entities.ElectionsVotes;

namespace Sadvo.Persistence.EntityConfigurationsORM
{
    public class ElectionConfiguration : IEntityTypeConfiguration<Election>
    {
        public void Configure(EntityTypeBuilder<Election> builder)
        {
            builder.ToTable(nameof(Election));
            builder.HasKey(e => e.ElectionId);
            builder.HasIndex(e => e.nameElections)
                .IsUnique();
            builder.HasIndex(e => e.dateElections)
                .IsUnique();


            builder.Property(e => e.nameElections)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(e => e.dateElections)
                .IsRequired();

            builder.Property(e => e.cantElectivePositions)
                .IsRequired();

            builder.Property(e => e.cantPartyPolitical)
                .IsRequired();


            builder.Property(e => e.isActiveElection)
                .IsRequired()
                .HasColumnType("bit")
                .HasDefaultValue(false);

            builder.HasMany(e => e.electivePosition)
                .WithOne(ep => ep.election)
                .HasForeignKey(e => e.ElectionID)
                .HasConstraintName("FK_ELECTIONSPOSITIONSELECTIONS")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.candidatos)
                .WithOne(e => e.election)
                .HasForeignKey(c => c.ElectionID)
                .HasConstraintName("FK_CandidatosElection")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.partyPoliticals)
                .WithOne(e => e.election)
                .HasForeignKey(p => p.ElectionID)
                .HasConstraintName("FK_PartyPoliticalsElection")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.politicalLeaders)
                .WithOne(e => e.election)
                .HasForeignKey(p => p.ElectionID)
                .HasConstraintName("FK_PoliticalLeadersElection")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(v => v.votes)
                .WithOne(e => e.election)
                .HasForeignKey(v => v.ElectionID)
                .HasConstraintName("FK_VotesElection")
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
