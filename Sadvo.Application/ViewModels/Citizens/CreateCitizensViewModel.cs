

using System.ComponentModel.DataAnnotations;

namespace Sadvo.Application.ViewModels.Citizens
{
    public class CreateCitizensViewModel
    {
        public required int Id { get; set; }

        [Required(ErrorMessage = "You Must enter username")]
        [DataType(DataType.Text)]
        public required string userName { get; set; }

        [Required(ErrorMessage = "You Must enter numberIdentity")]
        [DataType(DataType.Text)]
        public required string numberIdentity { get; set; }
        public string? Description { get; set; }
        public required bool isActive { get; set; }


    }
}
