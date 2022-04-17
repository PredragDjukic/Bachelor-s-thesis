global using System.Net;
using Diplomski.BLL.Exceptions;

namespace Diplomski.BLL.Utils.Constants
{
    public static class BusinessExceptions
    {
        public static BusinessException PasswordsDoNotMatch =>
            throw new BusinessException("Passwords do not match", HttpStatusCode.BadRequest);

        public static BusinessException PrivacyPolicyMustBeAccepted =>
            throw new BusinessException("Privacy policy must be accepted", HttpStatusCode.BadRequest);

        public static BusinessException TermsAndCondMustBeAccepted =>
            throw new BusinessException("Terms and conditions must be accepted", HttpStatusCode.BadRequest);
    }
}
