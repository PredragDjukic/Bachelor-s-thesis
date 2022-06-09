namespace Diplomski.BLL.DTOs.UserDtos;

public class UserUpdateDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Nationality { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
}