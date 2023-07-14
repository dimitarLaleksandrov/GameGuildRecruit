using GameGuildRecruit.Web.Services;
using GameGuildRecruit.Web.Services.Interfaces;
using GameGuildRecruit.Web.ViewModels.Banner;
using GameGuildRecruit.Web.ViewModels.Game;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
                var bannerModel = await bannerService.GetNewBannerModelAsync();

                return View(bannerModel);
            }
            catch (Exception)
            {

                return RedirectToAction("CreateAndEditError", "Errors");
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(Guid id, BannerFormModel bannerModel)
        {
            if (!ModelState.IsValid)
            {
                return View(bannerModel);
            }

            try
            {
                await bannerService.AddBannerAsync(bannerModel, id);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {

                return RedirectToAction("CreateAndEditError", "Errors");
            }

        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ShowBanners()
        {
            try
            {
                //var bannersModels = await bannerService.GetBannersAsync();

                return View();
            }
            catch (Exception)
            {

                return RedirectToAction("EmptyGuildInfo", "Errors");
            }

        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ShowGames()
        {
            try
            {
                //var bannersModels = await bannerService.GetBannersAsync();

                return View();
            }
            catch (Exception)
            {

                return RedirectToAction("EmptyGuildInfo", "Errors");
            }

        }
    }
}
