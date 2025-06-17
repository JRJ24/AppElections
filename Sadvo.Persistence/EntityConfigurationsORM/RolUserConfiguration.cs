

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
            builder.HasAlternateKey(r => r.rolName);

            builder.Property(r => r.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(r => r.userId)
                .IsRequired();
            builder.Property(r => r.rolName)
                .IsRequired();
            builder.Property(r => r.userName)
                .IsRequired();
            builder.Property(r => r.isActive)
                .IsRequired();

            builder.HasMany<Roles>(r => r.role)
                .WithOne(ru => ru.rolUser)
                .HasPrincipalKey(ru => ru.rolName)
                .HasForeignKey(r => r.Name)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
