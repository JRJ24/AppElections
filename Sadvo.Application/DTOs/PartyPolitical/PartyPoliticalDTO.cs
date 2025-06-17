

namespace Sadvo.Application.DTOs.PartyPolitical
{
    public class PartyPoliticalDTO
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string siglasPartyPolitical { get; set; }
        public int ElectionID { get; set; }
        public required bool isActive { get; set; }

    }
}
