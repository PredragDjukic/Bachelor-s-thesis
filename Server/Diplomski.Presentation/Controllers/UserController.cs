using Diplomski.BLL.DTOs.UserDtos;
using Diplomski.BLL.Interfaces;
using Diplomski.BLL.Utils.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diplomski.Presentation.Controllers;

[ApiController]
public class UserController : BaseController
{
    private readonly IUserService _service;

    
    public UserController(IUserService service)
    {
        _service = service;
    }


    [Route(Routes.VerifyEmail)]
    [Authorize(Policy = "UnverifiedEmail")]
    public ActionResult VerifyEmail([FromBody] SecretCodeUserDto dto)
    {
        string token = _service.VerifyEmail(CurrentUserId, dto);

        return Ok(new { Token = token });
    }
    
    [Route(Routes.ResendSecretCode)]
    [Authorize(Policy = "UnverifiedEmail")]
    public ActionResult ResendSecretCode()
    {
        _service.ResendSecretCode(CurrentUserId);

        return Ok();
    }
}