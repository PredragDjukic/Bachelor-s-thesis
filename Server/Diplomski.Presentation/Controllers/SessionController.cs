using Diplomski.BLL.DTOs.SessionsDTOs;
using Diplomski.BLL.Interfaces;
using Diplomski.BLL.Utils.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diplomski.Presentation.Controllers;

[ApiController]
public class SessionController : BaseController
{
    private readonly ISessionService _service;

    
    public SessionController(ISessionService service)
    {
        _service = service;
    }

    [HttpPost]
    [Authorize]
    [Route(Routes.Sesssion)]
    public ActionResult OpenSession([FromBody] SessionCreateDto dto)
    {
        SessionReadDto result = _service.OpenSession(this.CurrentUserId, dto);

        return Ok(result);
    }

    [HttpPatch]
    [Authorize]
    [Route(Routes.Reserve)]
    public ActionResult Reserve([FromBody] SessionReserveDto dto)
    {
        SessionReadDto result = _service.Reserve(this.CurrentUserId, dto);

        return Ok(result);
    }
    
    [HttpPatch]
    [Authorize]
    [Route(Routes.Cancel)]
    public ActionResult Reserve([FromRoute] int id)
    {
        SessionReadDto result = _service.Cancel(this.CurrentUserId, id);

        return Ok(result);
    }
}