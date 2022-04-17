using Diplomski.BLL.DTOs;
using Diplomski.BLL.Interfaces;
using Diplomski.BLL.Utils.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Diplomski.Presentation.Controllers
{
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IUserService _userService;


        public AuthController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        [Route(Routes.Register)]
        public ActionResult Register([FromBody] UserRegisterDto dto)
        {
            string token = _userService.Register(dto);

            return Ok(new { Token = token});
        }
    }
}
