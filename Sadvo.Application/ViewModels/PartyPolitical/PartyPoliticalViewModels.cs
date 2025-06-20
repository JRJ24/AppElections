namespace Sadvo.Application.ViewModels.PartyPolitical
{
    public class PartyPoliticalViewModels
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string siglasPartyPolitical { get; set; }
        public int ElectionID { get; set; }
        public string? Description { get; set; }
        public required string status { get; set; }
    }
}
