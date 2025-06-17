using Sadvo.Domain.Entities.Configuration;
using Sadvo.Domain.Entities.Elections;


namespace Sadvo.Domain.Entities.ElectionsVotes
{
    public class Election
    {
        public required int ElectionId { get; set; }
        public required string nameElections { get; set; }
        public DateTime? dateElections { get; set; }
        public int cantPartyPolitical { get; set; }
        public int cantElectivePositions { get; set; }
        public bool isActiveElection { get; set; }

        public ICollection<ElectivePositions>? electivePosition { get; set; }
        public ICollection<PartyPolitical>? partyPoliticals { get; set; }
        public ICollection<Candidatos>? candidatos { get; set; }
        public ICollection<PoliticalLeader>? politicalLeaders { get; set; }

        public ICollection<Votes>? votes { get; set; }
    }
}
