

using System.ComponentModel.DataAnnotations;

namespace Sadvo.Application.ViewModels.Users
{
    public class UpdateUserViewModel
    {
        public required int Id { get; set; }

        [Required(ErrorMessage = "You must enter your Name")]
        [DataType(DataType.Text)]
        public required string Name { get; set; }

        [Required(ErrorMessage = "You must enter your lastname")]
        [DataType(DataType.Text)]
        public required string lastname { get; set; }

        [Required(ErrorMessage = "You must enter your email of user")]
        [DataType(DataType.EmailAddress)]
        public required string email { get; set; }

        [Required(ErrorMessage = "You must enter your username")]
        [DataType(DataType.Text)]
        public required string userName { get; set; }

        [Required(ErrorMessage = "You must enter your Password")]
        [DataType(DataType.Password)]
        public required string password { get; set; }

        [Compare(nameof(password), ErrorMessage = "Password must match")]
        [DataType(DataType.Password)]
        public required string confirmPassword { get; set; }
        public string? Description { get; set; }

    }
}
