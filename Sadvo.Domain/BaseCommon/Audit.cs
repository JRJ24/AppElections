

namespace Sadvo.Domain.BaseCommon
{
    public class Audit
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required bool isActive { get; set; }
    }
}
