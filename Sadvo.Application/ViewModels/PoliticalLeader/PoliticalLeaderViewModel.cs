

namespace Sadvo.Application.ViewModels.PoliticalLeader
{
    public class PoliticalLeaderViewModel
    {
        public required int Id { get; set; }
        public required string userName { get; set; }
        public required string siglasPartyPolitical { get; set; }
        public int ElectionID { get; set; }
        public required string status { get; set; }
    }
}
