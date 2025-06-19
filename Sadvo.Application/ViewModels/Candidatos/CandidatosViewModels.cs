namespace Sadvo.Application.ViewModels.Candidatos
{
    public class CandidatosViewModels
    {
        public required int Id { get; set; }
        public required string FullName { get; set; }
        public string? Description { get; set; }
        public required string foto { get; set; }
        public required string Asociado { get; set; }
        public int ElectionID { get; set; }
        public required string status { get; set; }

    }
}
