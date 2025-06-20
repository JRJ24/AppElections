﻿

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sadvo.Domain.Entities.ElectionsVotes.Citizen;

namespace Sadvo.Persistence.EntityConfigurationsORM
{
    public class CitizenConfiguration : IEntityTypeConfiguration<Citizens>
    {
        public void Configure(EntityTypeBuilder<Citizens> builder) 
        {
            builder.ToTable(nameof(Citizens));
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.numberIdentity)
                .IsUnique();
            builder.HasIndex(x => x.userName)
                .IsUnique();

            builder.Property(x => x.userName)
               .IsRequired()
               .HasMaxLength(100);

            builder.Property(x => x.numberIdentity)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(x => x.isVoted)
                .IsRequired()
                .HasColumnType("bit")
                .HasDefaultValue(false);

            builder.Property(x => x.isActive)
                .IsRequired()
                .HasColumnType("bit")
                .HasDefaultValue(true);
        }
    }
}
