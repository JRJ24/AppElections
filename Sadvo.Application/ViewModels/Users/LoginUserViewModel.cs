
using System.ComponentModel.DataAnnotations;

namespace Sadvo.Application.ViewModels.Users
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "You must enter your username")]
        [DataType(DataType.Text)]
        public required string userName { get; set; }

        [Required(ErrorMessage = "You must enter your Password")]
        [DataType(DataType.Password)]
        public required string password { get; set; }
    }
}
