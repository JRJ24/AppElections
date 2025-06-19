

namespace Sadvo.Application.ViewModels.ElectivePositions
{
    public class ElectivePositionsViewModel
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public int ElectionID { get; set; }
        public string? Description { get; set; }
        public required string status { get; set; }

    }
}
