using Sadvo.Domain.BaseCommon;
using Sadvo.Domain.Entities.Configuration;
using Sadvo.Domain.Entities.ElectionsVotes.Citizen;

namespace Sadvo.Domain.Entities.Security
{
    public class Users : Audit
    {
        public required string lastname { get; set; }
        public required string email { get; set; }
        public required string userName { get; set; }
        public required string password { get; set; }

        public PoliticalLeader? politicalLeaders { get; set; }
        public Citizens? citizens { get; set; }
        public ICollection<RolUsers>? rolUsers {  get; set; }
    }
}
