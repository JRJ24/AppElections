using Sadvo.Domain.BaseCommon;

namespace Sadvo.Domain.Entities.Security
{
    public class Roles 
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required bool isActive { get; set; }
        public RolUsers? rolUser { get; set; }
    }
}
