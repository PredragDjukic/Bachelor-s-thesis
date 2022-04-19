global using System.Net;
using Diplomski.BLL.Exceptions;

namespace Diplomski.BLL.Utils.Constants
{
    public static class BusinessExceptions
    {
        #region User
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
        
        #endregion
    }
}
