global using System.Net;
using Diplomski.BLL.Exceptions;

namespace Diplomski.BLL.Utils.Constants
{
    public static class BusinessExceptions
    {
        #region User
        public static BusinessException UserDoesNotExist =>
            throw new BusinessException("User with provided Id does not exists", HttpStatusCode.BadRequest);
        
        public static BusinessException UserDoesNotExistEmail =>
            throw new BusinessException("User with provided email does not exists", HttpStatusCode.BadRequest);
        
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
        
        public static BusinessException UserCanNotBeDeletedReservedOrCompletedSessions =>
            throw new BusinessException("User can not be deleted while sessions are reserved or completed", HttpStatusCode.BadRequest);
        
        public static BusinessException UserCanNotBeDeletedActiveBundles =>
            throw new BusinessException("User can not be deleted while bundles are active", HttpStatusCode.BadRequest);
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
        
        public static BusinessException CanNotDeleteOfAnotherTrainer =>
            throw new BusinessException("Can not delete package from another trainer", HttpStatusCode.NotFound);
        
        public static BusinessException CanNotUpdateOfAnotherTrainer =>
            throw new BusinessException("Can not update package from another trainer", HttpStatusCode.NotFound);
        
        public static BusinessException NoPackages =>
            throw new BusinessException("List of packages is empty", HttpStatusCode.NoContent);

        #endregion
        
        #region Bundle
        
        public static BusinessException BundleDoesNotExist =>
            throw new BusinessException("Bundle with provided Id does not exists", HttpStatusCode.NotFound);
        
        public static BusinessException CanNotDeleteBundleFromAnother =>
            throw new BusinessException("Can not delete bundle from another user", HttpStatusCode.NotFound);
        
        public static BusinessException CanNotAccessBundle =>
            throw new BusinessException("Logged in user can not get this bundle", HttpStatusCode.BadRequest);
        
        public static BusinessException NoBundles =>
            throw new BusinessException("List of bundles is empty", HttpStatusCode.NoContent);
        
        public static BusinessException BundleIsInactive =>
            throw new BusinessException("Bundle is inactive", HttpStatusCode.BadRequest);
        
        
        #endregion
        
        #region Session
        
        public static BusinessException SessionStartInThePast =>
            throw new BusinessException("Session start can not be in the past", HttpStatusCode.BadRequest);
        
        public static BusinessException SessionOverlap =>
            throw new BusinessException("Session overlaps with existing sessions", HttpStatusCode.BadRequest);
        
        public static BusinessException SessionDoesNotExist =>
            throw new BusinessException("Session with provided id does not exists", HttpStatusCode.NotFound);
        
        public static BusinessException CanNotCancelSession =>
            throw new BusinessException("Session can not be canceled", HttpStatusCode.BadRequest);
        
        public static BusinessException SessionNotReserved =>
            throw new BusinessException("Session is not reserved", HttpStatusCode.BadRequest);
        
        #endregion

        #region Payments

        public static BusinessException TrainerCanNotBeCustomer =>
            throw new BusinessException("Trainer can not have a customer account", HttpStatusCode.BadRequest);
        
        public static BusinessException UserDoesNotHaveCustomerId =>
            throw new BusinessException("Provided user does not have a customerId", HttpStatusCode.BadRequest);
        
        public static BusinessException PaymentFailed =>
            throw new BusinessException("Payment has failed", HttpStatusCode.InternalServerError);

        #endregion
    }
}
