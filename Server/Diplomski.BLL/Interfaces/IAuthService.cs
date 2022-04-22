namespace Diplomski.BLL.Interfaces
{
    public interface IAuthService
    {
        string GenerateJwt(int userId, int role, bool isEmailVerified);
        Dictionary<string, object> ValidateTokenAndGetClaims(string token);
    }
}
