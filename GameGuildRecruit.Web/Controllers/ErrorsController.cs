using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameGuildRecruit.Web.Controllers
{
    public class ErrorsController : BaseController
    {



        [Authorize]
        [HttpGet]
        public async Task<IActionResult> EmptyGuildInfo()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> CreateAndEditError()
        {
            return View();
        }
    }
}
