

namespace Sadvo.Application.DTOs.Citizens
{
    public class CitizensDTO
    {
        public required int Id { get; set; }
        public required string userName { get; set; }
        public required string numberIdentity { get; set; }
        public required bool isVoted { get; set; }
        public string? Description { get; set; }
        public required bool isActive { get; set; }
    }
}
