using Sadvo.Domain.BaseCommon;
using Sadvo.Domain.Entities.Security;

namespace Sadvo.Domain.Entities.Configuration
{
    public class PoliticalLeader
    {
        public required int Id { get; set; }
        public required string userName { get; set; }
        public required string siglasPartyPolitical { get; set; }

        public PartyPolitical? partyPolitical { get; set; }
        public Users? user { get; set; }
    }
}
