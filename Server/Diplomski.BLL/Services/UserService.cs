using Diplomski.BLL.DTOs;
using Diplomski.BLL.Helpers;
using Diplomski.BLL.Interfaces;
using Diplomski.BLL.Utils.Constants;
using Diplomski.DAL.Entities;
using Diplomski.DAL.Interfaces;

namespace Diplomski.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IEmailService _emailService;


        public UserService(IUserRepository repo, IEmailService emailService)
        {
            this._repo = repo;
            this._emailService = emailService;
        }


        public string Register(UserRegisterDto dto)
        {
            this.ValidateUserRegisterDto(dto);
            this.DoesExistsByEmailOrPhoneNumber(dto);

            User user = new()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = HashHelper.HashValue(dto.Password),
                Username = dto.Username,
                PhoneNumber = dto.PhoneNumber,
                Nationality = dto.Nationality,
                IsEmailVerified = false,
                IsPhoneNumberVerified = false,
                SecretCode = CodeHelper.GenerateSecretCode(),
                SecretCodeExpiry = DateTimeHelper.GenerateSecretCodeExpiryDate(),
                AreTermsAndServicesAccepted = dto.AreTermsAndServicesAccepted,
                IsPrivacyPolicyAccepted = dto.IsPrivacyPolicyAccepted,
                DateOfBirth = dto.DateOfBirth,
            };

            _repo.Register(user);

            _emailService.SendVerificationCode(user.Email, user.SecretCode);

            //generate jwt token

            return "token";
        }

        private void ValidateUserRegisterDto(UserRegisterDto dto)
        {
            if (dto.Password != dto.ConfirmPassword)
                throw BusinessExceptions.PasswordsDoNotMatchException;

            if (!dto.IsPrivacyPolicyAccepted)
                throw BusinessExceptions.PrivacyPolicyFalseException;

            if (!dto.AreTermsAndServicesAccepted)
                throw BusinessExceptions.TermsAndCondFalseException;

            this.IsUsersAgeValid(dto.DateOfBirth);
        }

        private void IsUsersAgeValid(DateTime dateOfBirth)
        {
            if (DateTimeHelper.GetYearDifferenceFromNow(dateOfBirth) < LiteralConsts.UserMinimalAge)
                throw BusinessExceptions.UsersAgeException;
        }

        private void DoesExistsByEmailOrPhoneNumber(UserRegisterDto dto)
        {
            if (_repo.CheckIfExistsByEmail(dto.Email))
                throw BusinessExceptions.UserEmailAlreadyExistsException;

            if (_repo.CheckIfExistsByPhoneNumber(dto.PhoneNumber))
                throw BusinessExceptions.UserPhoneNumberAlreadyExistsException;
        }
    }
}

