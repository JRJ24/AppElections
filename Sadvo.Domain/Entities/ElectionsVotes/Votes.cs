

using Sadvo.Domain.Entities.Configuration;
using Sadvo.Domain.Entities.ElectionsVotes;
using Sadvo.Domain.Entities.ElectionsVotes.Citizen;

namespace Sadvo.Domain.Entities.Elections
{
    public class Votes
    {
        // PK
        public required int ID { get; set; }
        // FK
        public required int citizensID { get; set; }
        public required string siglasPartyPolitical { get; set; }
        public required int candidatosID { get; set; }
        public int ElectionID { get; set; }
        public required bool isActiveVote { get; set; }

        // Navigations
        public Citizens? citizens {  get; set; }
        public PartyPolitical? partyPoliticals { get; set; }
        public Candidatos? candidatos { get; set; }
        public Election? election { get; set; }
    }
}
