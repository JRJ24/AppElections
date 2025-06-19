

namespace Sadvo.Application.ViewModels.ElectivePositions
{
    public class UpdateElectivePositionsViewModel
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public int ElectionID { get; set; }
        public string? Description { get; set; }
        public required bool isActive { get; set; }
    }
}
