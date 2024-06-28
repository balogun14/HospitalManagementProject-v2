using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementProject.ViewModels.AuthViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email is required!")]
        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirm password do not match.")]
        public required string ConfirmPassword { get; set; }
    }
}