
namespace Sadvo.Application.ViewModels.Roles
{
    public class RolesViewModel
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required bool isActive { get; set; }
    }
}
