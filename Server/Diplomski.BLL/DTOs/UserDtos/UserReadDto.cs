namespace Diplomski.BLL.DTOs.UserDtos;

public class UserReadDto
{
    public int Id { get; set; }
    public int UserType { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Nationality { get; set; } = null!;
    public bool IsEmailVerified { get; set; }
    public bool IsPhoneNumberVerified { get; set; }
    public bool AreTermsAndServicesAccepted { get; set; }
    public bool IsPrivacyPolicyAccepted { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}