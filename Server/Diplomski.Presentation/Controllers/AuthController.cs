using Diplomski.BLL.DTOs;
using Diplomski.BLL.DTOs.UserDtos;
using Diplomski.BLL.Interfaces;
using Diplomski.BLL.Utils.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diplomski.Presentation.Controllers
{
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;


        public AuthController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }


        [HttpPost]
        [Route(Routes.Register)]
        [AllowAnonymous]
        public ActionResult Register([FromBody] UserRegisterDto dto)
        {
            string token = _userService.Register(dto);

            return Ok(new { Token = token});
        }
        
        [HttpPost]
        [Route(Routes.Login)]
        [AllowAnonymous]
        public ActionResult Login([FromBody] UserLoginDto dto)
        {
            string token = _authService.Login(dto);

            return Ok(new { Token = token });
        }
    }
}
