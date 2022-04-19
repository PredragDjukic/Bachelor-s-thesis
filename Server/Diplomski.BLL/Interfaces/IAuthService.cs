namespace Diplomski.BLL.Interfaces
{
    public interface IAuthService
    {
        string GenerateJwt(int role, bool isEmailVerified);
        Dictionary<string, object> ValidateTokenAndGetClaims(string token);
    }
}
