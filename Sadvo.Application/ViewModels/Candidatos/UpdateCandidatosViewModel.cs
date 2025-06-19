using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace Sadvo.Application.ViewModels.Candidatos
{
    internal class UpdateCandidatosViewModel
    {
        public required int Id { get; set; }
        [Required(ErrorMessage = "You must enter your name")]
        [DataType(DataType.Text)]
        public required string Name { get; set; }

        [Required(ErrorMessage = "You must enter your lastname")]
        [DataType(DataType.Text)]
        public required string lastname { get; set; }

        [DataType(DataType.Upload)]
        [Required(ErrorMessage = "You must enter the foto")]
        public IFormFile? foto { get; set; }
        public required bool isAssocciate { get; set; }
        public int ElectionID { get; set; }
        public required bool isActive { get; set; }
    }
}
