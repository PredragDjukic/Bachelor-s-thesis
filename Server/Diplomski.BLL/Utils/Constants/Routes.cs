﻿namespace Diplomski.BLL.Utils.Constants
{
    public static class Routes
    {
        private const string Base = "api/";

        //Auth
        public const string Auth = Base + "auth/";
        public const string Register = Auth + "register/";
        public const string Login = Auth + "login/";
        public const string VerifyEmail = Auth + "verify-email/";
        
        //user
        public const string User = Base + "user/";
        public const string LoggedInData = User + "get-data/";
        public const string ResendSecretCode = User + "resend-code/";
        
        //Package
        public const string Package = Base + "package/";
        public const string PackageId = Package + "{id}/";
        
        //Bundle
        public const string Bundle = Base + "bundle/";
    }
}
