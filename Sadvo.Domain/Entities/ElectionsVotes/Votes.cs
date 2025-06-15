

using Sadvo.Domain.Entities.Configuration;
using Sadvo.Domain.Entities.ElectionsVotes;
using Sadvo.Domain.Entities.ElectionsVotes.Citizen;

namespace Sadvo.Domain.Entities.Elections
{
    public class Votes
    {
        // PK
        public required int ID { get; set; }
        public required int VoteNumber { get; set; }
        // FK
        public required int citizensID { get; set; }
        public required string citizensName { get; set; }
        public required string siglasPartyPolitical { get; set; }
        public required string candidatosName { get; set; }

        // Navigations
        public Citizens? citizens {  get; set; }
        public ICollection<PartyPolitical>? partyPoliticals { get; set; }
        public ICollection<Candidatos>? candidatos { get; set; }
    }
}
