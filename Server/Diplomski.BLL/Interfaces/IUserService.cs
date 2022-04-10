using Diplomski.BLL.DTOs;
using Diplomski.DAL.Entities;

namespace Diplomski.BLL.Interfaces
{
    public interface IUserService
    {
        string Register(UserRegisterDto dto);
    }
}
