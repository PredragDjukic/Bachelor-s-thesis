namespace Diplomski.BLL.Interfaces
{
    public interface IAuthService
    {
        string GenerateJwt(int role);
    }
}
