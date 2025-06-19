
namespace Sadvo.Application.ViewModels.Votes
{
    public class SaveVotesViewModel
    {
        public required int ID { get; set; }
        public required int VoteNumber { get; set; }
        public required int citizensID { get; set; }
        public required string siglasPartyPolitical { get; set; }
        public required string candidatosName { get; set; }
        public int ElectionID { get; set; }
    }
}
