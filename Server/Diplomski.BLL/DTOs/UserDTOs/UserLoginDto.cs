using System.ComponentModel.DataAnnotations;
using Diplomski.BLL.Utils.Constants;

namespace Diplomski.BLL.DTOs.UserDtos;

public class UserLoginDto
{
    [Required]
    [EmailAddress(ErrorMessage = ValidationErrors.EmailInvalid)]
    public string Email { get; set; } = null!;
    
    [Required]
    [MinLength(8, ErrorMessage = ValidationErrors.PasswordMinimalLenght)]
    public string Password { get; set; } = null!;
}