using Diplomski.DAL.Entities;

namespace Diplomski.DAL.Mappers;

internal static class UserMapper
{
    internal static void ToUpdate(this User toUpdate, User newEntity)
    {
        toUpdate.FirstName = newEntity.FirstName;
        toUpdate.LastName = newEntity.LastName;
        toUpdate.Email = newEntity.Email;
        toUpdate.Password = newEntity.Password;
        toUpdate.Username = newEntity.Username;
        toUpdate.PhoneNumber = newEntity.PhoneNumber;
        toUpdate.Nationality = newEntity.Nationality;
        toUpdate.IsEmailVerified = newEntity.IsEmailVerified;
        toUpdate.IsPhoneNumberVerified = newEntity.IsPhoneNumberVerified;
        toUpdate.SecretCode = newEntity.SecretCode;
        toUpdate.SecretCodeExpiry = newEntity.SecretCodeExpiry;
        toUpdate.AreTermsAndServicesAccepted = newEntity.AreTermsAndServicesAccepted;
        toUpdate.IsPrivacyPolicyAccepted = newEntity.IsPhoneNumberVerified;
        toUpdate.DateOfBirth = newEntity.DateOfBirth;
    }
}