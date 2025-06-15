
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sadvo.Domain.Entities.Configuration;
using Sadvo.Domain.Entities.Security;

namespace Sadvo.Persistence.EntityConfigurationsORM
{
    public class UsersConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            #region Indexes
            builder.ToTable(nameof(Users));
            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => x.email)
                .HasName("UQ_KEY_EMAIL");
            builder.HasAlternateKey(x => x.userName)
                .HasName("UQ_KEY_USERNAME");
            #endregion

            #region Propiedades
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(25);
            builder.Property(x => x.lastname)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.email)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(x => x.userName)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.password)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(x => x.isActive)
               .IsRequired();
            #endregion

            #region Relationship
            builder.HasOne(pl => pl.politicalLeaders)
                .WithOne(u => u.user)
                .HasPrincipalKey<Users>(u => u.userName)
                .HasForeignKey<PoliticalLeader>(pl => pl.userName)
                .HasConstraintName("FK_USERNAME_POLITICAL_LEADERS")
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

        }
    }
}
