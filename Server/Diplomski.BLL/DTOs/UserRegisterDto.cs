using Diplomski.BLL.Utils.Constants;
using Diplomski.BLL.Validations;
using System.ComponentModel.DataAnnotations;
using Diplomski.BLL.Enums;

namespace Diplomski.BLL.DTOs
{
    public class UserRegisterDto
    {
        [Required]
        public UserType UserType { get; set; }
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        [EmailAddress(ErrorMessage = ValidationErrors.EmailInvalid)]
        public string Email { get; set; } = null!;
        [Required]
        [MinLength(8, ErrorMessage = ValidationErrors.PasswordMinimalLenght)]
        public string Password { get; set; } = null!;
        [Required]
        public string ConfirmPassword { get; set; } = null!;
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        public string PhoneNumber { get; set; } = null!;
        [Required]
        public string Nationality { get; set; } = null!;
        [Required]
        public bool AreTermsAndServicesAccepted { get; set; }
        [Required]
        public bool IsPrivacyPolicyAccepted { get; set; }
        [Required]
        [DateTimeValidation(ErrorMessage = ValidationErrors.PastDateTime)]
        public DateTime DateOfBirth { get; set; }
    }
}
