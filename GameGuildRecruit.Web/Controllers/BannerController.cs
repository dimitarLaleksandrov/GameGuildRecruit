using GameGuildRecruit.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameGuildRecruit.Web.Controllers
{
    public class BannerController : BaseController
    {

        private readonly IBannerService bannerService;


        public BannerController(IBannerService bannerService)
        {
            this.bannerService = bannerService;

        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {

                return RedirectToAction("CreateAndEditError", "Errors");
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(Guid id, string userModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userModel);
            }

            try
            {
               

                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {

                return RedirectToAction("CreateAndEditError", "Errors");
            }
        }
    }
}
