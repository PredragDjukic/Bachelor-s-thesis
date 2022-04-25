using System.ComponentModel.DataAnnotations;
using Diplomski.BLL.Utils.Constants;

namespace Diplomski.BLL.DTOs.UserDtos;

public class SecretCodeUserDto
{
    [Required]
    [StringLength(6, ErrorMessage = ValidationErrors.SecretCodeLenght)]
    public string SecretCode { get; set; } = null!;
}