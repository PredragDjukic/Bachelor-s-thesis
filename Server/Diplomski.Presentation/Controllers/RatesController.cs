using Diplomski.BLL.DTOs.RateDTOs;
using Diplomski.BLL.Interfaces;
using Diplomski.BLL.Utils.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diplomski.Presentation.Controllers;

[ApiController]
public class RatesController : BaseController
{
    private readonly IRateService _service;


    public RatesController(IRateService service)
    {
        _service = service;
    }

    [HttpPost]
    [Authorize]
    [Route(Routes.Rate)]
    public ActionResult Create([FromBody] RateCreateDto dto)
    {
        var result = _service.Create(this.CurrentUserId, dto);

        return Ok(result);
    }

    [HttpGet]
    [Authorize]
    [Route(Routes.RateBySession)]
    public ActionResult GetBySession([FromRoute] int sessionId)
    {
        var result = _service.GetBySession(sessionId);

        return Ok(result);
    }
    
    [HttpGet]
    [Authorize]
    [Route(Routes.RateByTrainer)]
    public ActionResult GetByTrainer([FromRoute] int trainerId)
    {
        var result = _service.GetByTrainerId(trainerId);

        return Ok(result);
    }
}