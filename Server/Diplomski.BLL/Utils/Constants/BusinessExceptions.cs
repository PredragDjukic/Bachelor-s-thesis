global using System.Net;
using Diplomski.BLL.Exceptions;

namespace Diplomski.BLL.Utils.Constants
{
    public static class BusinessExceptions
    {
        #region User
        public static BusinessException UserDoesNotExist =>
            throw new BusinessException("User with provided Id does not exists", HttpStatusCode.BadRequest);
        
        public static BusinessException TrainerDoesNotExist =>
            throw new BusinessException("Trainer with provided Id does not exists", HttpStatusCode.BadRequest);
        
        public static BusinessException ExerciserDoesNotExist =>
            throw new BusinessException("Exerciser with provided Id does not exists", HttpStatusCode.BadRequest);
        
        public static BusinessException SecretCodeInvalid =>
            throw new BusinessException("Secret code is not valid", HttpStatusCode.BadRequest);
        
        public static BusinessException PasswordsDoNotMatchException =>
            throw new BusinessException("Passwords do not match", HttpStatusCode.BadRequest);

        public static BusinessException PrivacyPolicyFalseException =>
            throw new BusinessException("Privacy policy must be accepted", HttpStatusCode.BadRequest);

        public static BusinessException TermsAndCondFalseException =>
            throw new BusinessException("Terms and conditions must be accepted", HttpStatusCode.BadRequest);

        public static BusinessException UserEmailAlreadyExistsException =>
            throw new BusinessException("User with provider email already exists", HttpStatusCode.BadRequest);

        public static BusinessException UserPhoneNumberAlreadyExistsException =>
            throw new BusinessException("User with provider phone number already exists", HttpStatusCode.BadRequest);
        public static BusinessException UsersAgeException =>
            throw new BusinessException("User must be older then 14 years", HttpStatusCode.BadRequest);
        #endregion

        #region Auth
        public static BusinessException NotAuthorizedException =>
            throw new BusinessException("Not authorized", HttpStatusCode.BadRequest);
        
        public static BusinessException SecretCodeExpired =>
            throw new BusinessException("Secret code has expired", HttpStatusCode.BadRequest);
        
        public static BusinessException PasswordIncorrect =>
            throw new BusinessException("Password is not valid", HttpStatusCode.BadRequest);
        
        #endregion

        #region Package

        public static BusinessException PackageDoesNotExist =>
            throw new BusinessException("Package with provided id does not exists", HttpStatusCode.NotFound);

        #endregion
    }
}
