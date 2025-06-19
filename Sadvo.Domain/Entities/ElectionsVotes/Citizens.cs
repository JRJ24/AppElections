using Sadvo.Domain.BaseCommon;
using Sadvo.Domain.Entities.Elections;
using Sadvo.Domain.Entities.Security;

namespace Sadvo.Domain.Entities.ElectionsVotes.Citizen
{
    public class Citizens 
    {
        public required int Id { get; set; }
        public required string userName { get; set; }
        public required string numberIdentity { get; set; }
        public required bool isVoted { get; set; }
        public string? Description { get; set; }
        public required bool isActive { get; set; }

        public ICollection<Votes>? votes { get; set; }
        public Users? users { get; set; }
    }
}
