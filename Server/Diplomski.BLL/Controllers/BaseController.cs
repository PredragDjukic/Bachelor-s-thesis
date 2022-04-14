using Microsoft.AspNetCore.Mvc;

namespace Diplomski.BLL.Controllers
{
    public class BaseController : ControllerBase
    {
        protected int CurrentUserId {
            get => Convert.ToInt32(HttpContext?.Items["Id"]);
        }
    }
}
