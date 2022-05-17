using Diplomski.BLL.DTOs.BundleDTOs;
using Diplomski.BLL.Interfaces;
using Diplomski.BLL.Utils.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diplomski.Presentation.Controllers;

[ApiController]
public class BundleController : BaseController
{
    private readonly IBundleService _service;

    
    public BundleController(IBundleService service)
    {
        _service = service;
    }


    [HttpPost]
    [Route(Routes.Bundle)]
    [Authorize]
    public ActionResult Create([FromBody]BundleCreateDto dto)
    {
        BundleReadDto result = _service.Create(CurrentUserId, dto);

        return Ok(result);
    }
}