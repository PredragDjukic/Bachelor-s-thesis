using Diplomski.BLL.DTOs.UserDtos;
using Diplomski.DAL.Entities;

namespace Diplomski.BLL.Mappers;

internal static class UserMapper
{
    internal static UserReadDto ToReadDto(this User user) => new UserReadDto()
    {
        Id = user.Id,
        UserType = user.UserType,
        FirstName = user.FirstName,
        LastName = user.LastName,
        Email = user.Email,
        Username = user.Username,
        PhoneNumber = user.PhoneNumber,
        Nationality = user.Nationality,
        IsEmailVerified = user.IsEmailVerified,
        IsPhoneNumberVerified = user.IsPhoneNumberVerified,
        AreTermsAndServicesAccepted = user.AreTermsAndServicesAccepted,
        IsPrivacyPolicyAccepted = user.IsPrivacyPolicyAccepted,
        DateOfBirth = user.DateOfBirth,
        CreatedAt = user.CreatedAt,
        UpdatedAt = user.UpdatedAt
    };

    internal static void UpdateUser(this User user, UserUpdateDto dto)
    {
        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.Username = dto.Username;
        user.PhoneNumber = dto.PhoneNumber;
        user.Nationality = dto.Nationality;
        user.DateOfBirth = dto.DateOfBirth;
    }
}