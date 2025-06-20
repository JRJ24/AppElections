

namespace Sadvo.Application.ViewModels.Election
{
    public class ElectionViewModel
    {
        public required int ElectionId { get; set; }
        public required string nameElections { get; set; }
        public DateTime? dateElections { get; set; }

        // public int cantPartyPolitical { get; set; }
        // public int cantElectivePositions { get; set; }
        // public int cantCandidatos { get; set; }
       // public int yearElections { get; set; }
        public string status { get; set; }
    }
}
