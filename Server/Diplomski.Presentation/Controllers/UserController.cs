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

    
    [Route(Routes.ResendSecretCode)]
    [Authorize(Policy = "UnverifiedEmail")]
    public ActionResult ResendSecretCode()
    {
        _service.ResendSecretCode(this.CurrentUserId);

        return Ok();
    }
    
    [Route(Routes.LoggedInData)]
    [Authorize(Policy = "UnverifiedEmail")]
    public ActionResult GetLoggedInData()
    {
        UserReadDto user = _service.Get(this.CurrentUserId);

        return Ok(user);
    }
}