using Diplomski.BLL.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Diplomski.Presentation.Controllers
{
    public class BaseController : ControllerBase
    {
        protected int CurrentUserId { 
            get => Convert.ToInt32(
                HttpContext?
                    .User
                    .Claims
                    .FirstOrDefault(e => e.Type == Claims.Id.ToString()).Value
            ); 
        }
    }
}
