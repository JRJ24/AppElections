
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Sadvo.Application.ViewModels.PartyPolitical
{
    public class UpdatePartyPoliticalViewModel
    {
        public required int Id { get; set; }

        [Required(ErrorMessage = "You must enter name of party political")]
        [DataType(DataType.Text)]
        public required string Name { get; set; }

        [Required(ErrorMessage = "You must enter name of siglas")]
        [DataType(DataType.Text)]
        public required string siglasPartyPolitical { get; set; }

        [DataType(DataType.Upload)]
        [Required(ErrorMessage = "You must enter the logo")]
        public IFormFile? logoTypePartyPolitical { get; set; }

        public int ElectionID { get; set; }
        public string? Description { get; set; }
        public required bool isActive { get; set; }
    }
}
