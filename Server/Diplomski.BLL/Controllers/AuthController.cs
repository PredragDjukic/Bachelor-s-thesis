using Diplomski.BLL.Constants;
using Diplomski.BLL.DTOs;
using Diplomski.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Diplomski.BLL.Controllers
{
    [ApiController]
    [Route(Routes.Auth)]
    public class AuthController : BaseController
    {
        private readonly IUserService _service;


        public AuthController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult Register([FromBody] UserRegisterDto dto)
        {
            string token = _service.Register(dto);

            return Ok(new { Token = token });
        }
    }
}
