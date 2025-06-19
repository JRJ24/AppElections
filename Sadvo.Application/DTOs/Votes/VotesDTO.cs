

namespace Sadvo.Application.DTOs.Votes
{
    public class VotesDTO
    {
        public required int ID { get; set; }
        public required int citizensID { get; set; }
        public required string siglasPartyPolitical { get; set; }
        public required string candidatosName { get; set; }
        public int ElectionID { get; set; }
    }
}
