using Diplomski.BLL.Exceptions;
using Diplomski.BLL.Utils.Constants;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Diplomski.Presentation.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController : ControllerBase
{
    
    [Route("error-development")]
    public IActionResult HandleErrorDevelopment([FromServices] IHostEnvironment hostEnvironment)
    {
        if (!hostEnvironment.IsDevelopment())
        {
            return NotFound();
        }

        var exceptionHandlerFeature =
            HttpContext.Features.Get<IExceptionHandlerFeature>()!;

        if (exceptionHandlerFeature.Error is BusinessException)
        {
            var exception = exceptionHandlerFeature.Error as BusinessException;
            
            return Problem(
                detail: exceptionHandlerFeature.Error.StackTrace,
                title: exceptionHandlerFeature.Error.Message,
                statusCode: Convert.ToInt32(exception?.StatusCode)
            );
        }
        
        return Problem(
            detail: exceptionHandlerFeature.Error.StackTrace,
            title: exceptionHandlerFeature.Error.Message
        );
    }
    
    [Route("error")]
    public IActionResult HandleError([FromServices] IHostEnvironment hostEnvironment)
    {
        if (!hostEnvironment.IsDevelopment())
        {
            return NotFound();
        }

        var exceptionHandlerFeature =
            HttpContext.Features.Get<IExceptionHandlerFeature>()!;

        if (exceptionHandlerFeature.Error is BusinessException)
        {
            var exception = exceptionHandlerFeature.Error as BusinessException;
            
            return Problem(
                title: exceptionHandlerFeature.Error.Message,
                statusCode: Convert.ToInt32(exception?.StatusCode)
            );
        }
        
        return Problem(
            title: exceptionHandlerFeature.Error.Message
        );
    }
}