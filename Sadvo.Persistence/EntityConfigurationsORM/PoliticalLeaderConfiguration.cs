
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sadvo.Domain.Entities.Configuration;

namespace Sadvo.Persistence.EntityConfigurationsORM
{
    public class PoliticalLeaderConfiguration : IEntityTypeConfiguration<PoliticalLeader>
    {
        public void Configure(EntityTypeBuilder<PoliticalLeader> builder)
        {
            builder.ToTable(nameof(PoliticalLeader));
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(p => p.userName)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.siglasPartyPolitical)
                .IsRequired();
        }
    }
}
