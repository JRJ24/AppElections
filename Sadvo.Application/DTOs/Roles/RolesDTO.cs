namespace Sadvo.Application.DTOs.Roles
{
    public class RolesDTO
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required bool isActive { get; set; }
    }
}
