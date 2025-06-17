

namespace Sadvo.Application.DTOs.PoliticalLeader
{
    public class PoliticalLeaderDTO
    {
        public required int Id { get; set; }
        public required string userName { get; set; }
        public required string siglasPartyPolitical { get; set; }
        public int ElectionID { get; set; }
        public required bool isActive { get; set; }
    }
}
