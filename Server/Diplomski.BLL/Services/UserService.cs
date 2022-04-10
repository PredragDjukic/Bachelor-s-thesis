using Diplomski.BLL.DTOs;
using Diplomski.BLL.Exceptions;
using Diplomski.BLL.Interfaces;
using Diplomski.DAL.Entities;
using Diplomski.DAL.Interfaces;
using System.Net;

namespace Diplomski.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;


        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }


        public string Register(UserRegisterDto dto)
        {
            this.ValidateUserRegisterDto(dto);

            User user = new()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                //HASH
                Password = dto.Password,
                Username = dto.Username,
                PhoneNumber = dto.PhoneNumber,
                Nationality = dto.Nationality,
                IsEmailVerified = false,
                IsPhoneNumberVerified = false,
                //GENERATE
                SecretCode = "asdasd",
                SecretCodeExpiry = DateTime.UtcNow.AddMinutes(10),
                AreTermsAndServicesAccepted = dto.AreTermsAndServicesAccepted,
                IsPrivacyPolicyAccepted = dto.IsPrivacyPolicyAccepted,
                DateOfBirth = dto.DateOfBirth,
                ProfilePhotoUrl = dto.ProfilePhotoUrl
            };

            _repo.Register(user);

            //Send email

            return "token";
        }

        private void ValidateUserRegisterDto(UserRegisterDto dto)
        {
            if (dto.Password != dto.ConfirmPassword)
                throw new BusinessException("Passwords do not match", HttpStatusCode.BadRequest);

            if (dto.IsPrivacyPolicyAccepted)
                throw new BusinessException("Privacy policy must be accepted", HttpStatusCode.BadRequest);

            if (dto.AreTermsAndServicesAccepted)
                throw new BusinessException("Terms and conditions must be accepted", HttpStatusCode.BadRequest);
        }
    }
}
