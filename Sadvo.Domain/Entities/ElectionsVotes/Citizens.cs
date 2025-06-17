using Sadvo.Domain.BaseCommon;
using Sadvo.Domain.Entities.Elections;
using Sadvo.Domain.Entities.Security;

namespace Sadvo.Domain.Entities.ElectionsVotes.Citizen
{
    public class Citizens : Audit
    {
        public required string userName {  get; set; }  
        public required string lastname { get; set; }
        public required string email { get; set; }
        public required string numberIdentity { get; set; }
        public required bool isVoted { get; set; }

        public Votes? votes { get; set; }
        public Users? users { get; set; }
    }
}
