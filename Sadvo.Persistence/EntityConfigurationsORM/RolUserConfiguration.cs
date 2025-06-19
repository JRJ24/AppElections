

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sadvo.Domain.Entities.Security;

namespace Sadvo.Persistence.EntityConfigurationsORM
{
    public class RolUserConfiguration : IEntityTypeConfiguration<RolUsers>
    {
        public void Configure(EntityTypeBuilder<RolUsers> builder)
        {
            builder.ToTable(nameof(RolUsers));
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(r => r.userId)
                .IsRequired();
            builder.Property(r => r.rolID)
                .IsRequired();
            builder.Property(r => r.isActive)
                .IsRequired();


            builder.HasOne(r => r.user)
                 .WithMany(u => u.rolUsers)
                 .HasForeignKey(r => r.userId)
                 .HasConstraintName("FK_UserID_Users");

            builder.HasOne(r => r.role)
                 .WithMany(r => r.rolUsers)
                 .HasForeignKey(r => r.rolID)
                 .HasConstraintName("FK_RolID_Roles");


        }
    }
}

