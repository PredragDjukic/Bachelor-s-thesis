﻿using Diplomski.BLL.Constants;
using Diplomski.BLL.DTOs;
using Diplomski.BLL.Helpers;
using Diplomski.BLL.Interfaces;
using Diplomski.DAL.Entities;
using Diplomski.DAL.Interfaces;

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

            /*
             * 
             * CORS
             Check if user with same email already eists
                                     phone number already exists
            If older then 14

             */

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

            //Send email

            return "token";
        }

        private void ValidateUserRegisterDto(UserRegisterDto dto)
        {
            if (dto.Password != dto.ConfirmPassword)
                throw BusinessExceptions.PasswordsDoNotMatch;

            if (!dto.IsPrivacyPolicyAccepted)
                throw BusinessExceptions.PrivacyPolicyMustBeAccepted;

            if (!dto.AreTermsAndServicesAccepted)
                throw BusinessExceptions.TermsAndCondMustBeAccepted;
        }
    }
}

