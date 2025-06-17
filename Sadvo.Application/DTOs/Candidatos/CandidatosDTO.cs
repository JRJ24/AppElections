

namespace Sadvo.Application.DTOs.Candidatos
{
    public class CandidatosDTO
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string lastname { get; set; }
        public required string foto { get; set; }
        public required bool isAssocciate { get; set; }
        public required bool isActive { get; set; }
    }
}
