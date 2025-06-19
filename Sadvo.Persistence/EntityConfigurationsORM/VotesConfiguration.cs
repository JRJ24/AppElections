

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sadvo.Domain.Entities.Configuration;
using Sadvo.Domain.Entities.Elections;
using Sadvo.Domain.Entities.ElectionsVotes.Citizen;
using Sadvo.Domain.Entities.Security;

namespace Sadvo.Persistence.EntityConfigurationsORM
{
    public class VotesConfiguration : IEntityTypeConfiguration<Votes>
    {
        public void Configure(EntityTypeBuilder<Votes> builder)
        {
            builder.ToTable(nameof(Votes));
            builder.HasKey(v => v.ID);

            builder.Property(v => v.ID)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(v => v.citizensID)
                .IsRequired();

            builder.Property(v => v.siglasPartyPolitical)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(v => v.candidatosID)
                .IsRequired();

            builder.Property(v => v.isActiveVote)
                .IsRequired()
                .HasColumnType("bit")
                .HasDefaultValue(true);

            builder.HasOne(v => v.citizens)
                .WithMany(c => c.votes)
                .HasForeignKey(v => v.citizensID)
                .HasConstraintName("FK_CITIZENDSID");
            
            builder.HasOne(v => v.candidatos)
                .WithMany(c => c.votes)
                .HasForeignKey(v  => v.candidatosID)
                .HasConstraintName("FK_CandidatosID");


        }
    }
}
