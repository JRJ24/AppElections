
using Microsoft.EntityFrameworkCore;
using Sadvo.Domain.Entities.Configuration;
using Sadvo.Domain.Entities.Elections;
using Sadvo.Domain.Entities.ElectionsVotes;
using Sadvo.Domain.Entities.ElectionsVotes.Citizen;
using Sadvo.Domain.Entities.Security;
using System.Reflection;

namespace Sadvo.Persistence.Context
{
    public class AppElectionsContext : DbContext
    {
        public AppElectionsContext(DbContextOptions<AppElectionsContext> options) : base(options) { }
        
        #region Configuration
        public DbSet<PartyPolitical> partyPoliticals { get; set; }
        public DbSet<ElectivePositions> electivePositions { get; set; }
        public DbSet<PoliticalLeader> politicalLeaders { get; set; }
        public DbSet<AliancePolitical> aliancePoliticals { get; set; }
        public DbSet<Candidatos> candidatos { get; set; }
        #endregion

        #region ElectionsVotes
        public DbSet<Citizens> citizens { get; set; }
        public DbSet<Election> elections { get; set; }
        public DbSet<Votes> votes { get; set; }
        #endregion

        #region security
        public DbSet<Roles> roles { get; set; }
        public DbSet<RolUsers> rolUsers { get; set; }
        public DbSet<Users> users { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
