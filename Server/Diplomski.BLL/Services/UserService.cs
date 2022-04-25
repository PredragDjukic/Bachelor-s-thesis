using Diplomski.BLL.DTOs.UserDtos;
using Diplomski.BLL.Extensions;
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


        public User Create(UserRegisterDto dto)
        {
            this.ValidateUserRegisterDto(dto);
            this.DoesExistsByEmailOrPhoneNumber(dto);

            User user = new()
            {
                UserType = Convert.ToInt32(dto.UserType),
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
                SecretCodeExpiry = CodeHelper.GenerateSecretCodeExpiryDate(),
                AreTermsAndServicesAccepted = dto.AreTermsAndServicesAccepted,
                IsPrivacyPolicyAccepted = dto.IsPrivacyPolicyAccepted,
                DateOfBirth = dto.DateOfBirth,
            };

            _repo.Create(user);

            _emailService.SendVerificationCode(user.Email, user.SecretCode);

            return user;
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
        
        public User VerifyEmail(int loggedUserId, SecretCodeUserDto dto)
        {
            User user = this.Get(loggedUserId);

            this.ValidateSecretCodeAndExpiry(user, dto);

            user.IsEmailVerified = true;
            _repo.Update(user);
            
            return user;
        }

        private void ValidateSecretCodeAndExpiry(User user, SecretCodeUserDto dto)
        {
            DateTime expiryLimit = user.SecretCodeExpiry.AddMinutes(LiteralConsts.SecretCodeExpiryInMinutes);
            
            if (DateTime.UtcNow.IsGreater(expiryLimit))
                throw BusinessExceptions.SecretCodeExpired;

            if (user.SecretCode != dto.SecretCode)
                throw BusinessExceptions.SecretCodeInvalid;
        }
        
        public void ResendSecretCode(int loggedUserId)
        {
            User user = this.Get(loggedUserId);

            user.SecretCode = CodeHelper.GenerateSecretCode();
            user.SecretCodeExpiry = CodeHelper.GenerateSecretCodeExpiryDate();

            _repo.Update(user);
        }

        public User Get(string email)
        {
            User? user = _repo.Get(email);

            if (user == null)
                throw BusinessExceptions.UserDoesNotExist;

            return user;
        }
        
        private User Get(int id)
        {
            User? user = _repo.Get(id);

            if (user == null)
                throw BusinessExceptions.UserDoesNotExist;

            return user;
        }
    }
}

