using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameGuildRecruit.Web.Controllers
{
    public class ErrorsController : BaseController
    {



        [HttpGet]
        public IActionResult EmptyGuildInfo()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateAndEditError()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetContactError()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RemoveGuildInfoError()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SetAvatarError()
        {
            return View();
        }

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

        [HttpGet]
        public IActionResult CreateAndEditBannerError()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RemoveBannerError()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateAndEditGameError()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ShowGamesError()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RemoveGameError()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PageError()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BannerError()
        {
            return View();
        }
    }
}
