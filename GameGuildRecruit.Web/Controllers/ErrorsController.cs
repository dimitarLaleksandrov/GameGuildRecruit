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

        [Authorize]
        [HttpGet]
        public IActionResult GetContactError()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult RemoveGuildInfoError()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult SetAvatarError()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetUsersError()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RemoveContactError()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult CreateAndEditBannerError()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult RemoveBannerError()
        {
            return View();
        }


        [Authorize]
        [HttpGet]
        public IActionResult CreateAndEditGameError()
        {
            return View();
        }
    }
}
