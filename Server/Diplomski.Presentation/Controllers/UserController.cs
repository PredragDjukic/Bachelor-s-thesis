using Diplomski.BLL.DTOs.UserDtos;
using Diplomski.BLL.Interfaces;
using Diplomski.BLL.Utils.Constants;
using Diplomski.BLL.Utils.Models;
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

    
    [HttpPost]
    [Authorize(Policy = "UnverifiedEmail")]
    [Route(Routes.ResendSecretCode)]
    public ActionResult ResendSecretCode()
    {
        _service.ResendSecretCode(this.CurrentUserId);

        return Ok();
    }
    
    [HttpGet]
    [Authorize(Policy = "IdOnlyRequirement")]
    [Route(Routes.LoggedInData)]
    public ActionResult GetLoggedInData()
    {
        UserReadDto user = _service.GetRead(this.CurrentUserId);

        return Ok(user);
    }

    [HttpPost]
    [Authorize]
    [Route(Routes.UserCard)]
    public ActionResult AddCard([FromBody] CardModel model)
    {
        _service.AddCardToUser(this.CurrentUserId, model);

        return Ok();
    }
    
    [HttpGet]
    [Authorize]
    [Route(Routes.UserCard)]
    public ActionResult AddCard()
    {
        var result = _service.GetUserCards(this.CurrentUserId);

        return Ok(result);
    }
}