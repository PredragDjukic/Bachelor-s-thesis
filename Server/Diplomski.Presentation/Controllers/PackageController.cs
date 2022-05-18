using Diplomski.BLL.DTOs.PackageDTOs;
using Diplomski.BLL.Interfaces;
using Diplomski.BLL.Utils.Constants;
using Diplomski.Presentation.Attributes;
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

    [HttpGet]
    [Authorize]
    [Route(Routes.PackageId)]
    public ActionResult Get([FromRoute] int id)
    {
        PackageReadDto result = _service.GetRead(id);

        return Ok(result);
    }
    
    [HttpPut]
    [Authorize]
    [Route(Routes.PackageId)]
    public ActionResult Update([FromRoute] int id, [FromBody] PackageUpdateDto dto)
    {
        PackageReadDto result = _service.Update(CurrentUserId, id, dto);

        return Ok(result);
    }
    
    [HttpDelete]
    [Authorize]
    [Route(Routes.PackageId)]
    public ActionResult Delete([FromRoute] int id)
    {
        _service.Delete(CurrentUserId, id);

        return Ok();
    }
    
    
}