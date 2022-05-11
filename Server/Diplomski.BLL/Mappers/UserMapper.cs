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
}