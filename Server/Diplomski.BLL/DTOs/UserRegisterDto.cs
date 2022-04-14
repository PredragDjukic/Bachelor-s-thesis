namespace Diplomski.BLL.DTOs
{
    public class UserRegisterDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Nationality { get; set; } = null!;
        public bool AreTermsAndServicesAccepted { get; set; }
        public bool IsPrivacyPolicyAccepted { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
