using Diplomski.BLL.DTOs.PackageDTOs;
using Diplomski.BLL.Interfaces;
using Diplomski.BLL.Utils.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diplomski.Presentation.Controllers;

[ApiController]
public class PackageController : BaseController
{
    private readonly IPackageService _service;

    
    public PackageController(IPackageService service)
    {
        _service = service;
    }


    [HttpPost]
    [Authorize]
    [Route(Routes.Package)]
    public ActionResult Create([FromBody] PackageCreateDto dto)
    {
        PackageReadDto result = _service.Create(CurrentUserId, dto);

        return Ok(result);
    }
}