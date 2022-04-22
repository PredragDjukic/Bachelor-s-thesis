namespace Diplomski.BLL.Utils.Constants
{
    public static class Routes
    {
        private const string Base = "api/";

        //Auth
        public const string Auth = Base + "auth/";
        public const string Register = Auth + "register/";
        
        //user
        public const string User = Base + "user/";
        public const string VerifyEmail = User + "verify-email";
    }
}
