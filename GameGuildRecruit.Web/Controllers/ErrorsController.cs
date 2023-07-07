using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameGuildRecruit.Web.Controllers
{
    public class ErrorsController : BaseController
    {



        [Authorize]
        [HttpGet]
        public IActionResult EmptyGuildInfo()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult CreateAndEditError()
        {
            return View();
        }
    }
}
