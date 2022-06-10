namespace Diplomski.BLL.Utils.Constants
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
        public const string Trainer = User + "trainer/";
        public const string UserId = User + "{id}/";
        public const string LoggedInData = User + "get-data/";
        public const string ResendSecretCode = User + "resend-code/";
        public const string UserCard = User + "card/";
        public const string UserCardId = User + "card/{cardId}";
        public const string UserDefaultCard = UserCard + "default/";
        
        //Package
        public const string Package = Base + "package/";
        public const string PackageId = Package + "{id}/";
        public const string PackagesActiveByTrainer = Package + "active-trainer/{trainerId}";
        
        //Bundle
        public const string Bundle = Base + "bundle/";
        public const string BundleId = Bundle + "{id}/";
        public const string BundleAllTrainer = Bundle + "trainer/{id}/";
        public const string BundleAllExerciser = Bundle + "exerciser/{id}/";
        
        //Sessions
        public const string Sesssion = Base + "session/";
    }
}
