

namespace Sadvo.Application.DTOs.ElectivePositions
{
    public class ElectivePositionsDTO
    {
      
        public required int Id { get; set; }
        public required string Name { get; set; }
        public int ElectionID { get; set; }
        public string? Description { get; set; }
        public required bool isActive { get; set; }
    }
}
