
namespace Sadvo.Application.DTOs.Election
{
    public class ElectionDTO
    {
        public required int ElectionId { get; set; }
        public required string nameElections { get; set; }
        public DateTime? dateElections { get; set; }
        // public int cantPartyPolitical { get; set; }
        // public int cantElectivePositions { get; set; }

        public int yearElections { get; set; }
        public bool isActiveElection { get; set; }
    }
}
