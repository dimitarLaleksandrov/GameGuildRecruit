using GameGuildRecruit.Web.Services.Interfaces;
using GameGuildRecruit.Web.ViewModels.Banner;
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
                var bannerModel = await bannerService.GetNewBannerModelAsync();

                return View(bannerModel);
            }
            catch (Exception)
            {

                return RedirectToAction("CreateAndEditBannerError", "Errors");
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

                return RedirectToAction(bannerModel.GameName, "Pages");
            }
            catch (Exception)
            {

                return RedirectToAction("CreateAndEditBannerError", "Errors");
            }

        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var banner = await bannerService.GetBannerByIdAsync(id);

                return View(banner);
            }
            catch (Exception)
            {

                return RedirectToAction("CreateAndEditBannerError", "Errors");
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditBanner(BannerFormModel bannerModel)
        {
            if (!ModelState.IsValid)
            {
                return View(bannerModel);
            }

            try
            {
                await bannerService.EditBannerAsync(bannerModel);

                return RedirectToAction(bannerModel.GameName, "Pages");
            }
            catch (Exception)
            {

                return RedirectToAction("CreateAndEditBannerError", "Errors");
            }
        }

        [Authorize]
        public async Task<IActionResult> RemoveBanner(Guid id)
        {
            try
            {
                await bannerService.RemoveBannerAsync(id);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {

                return RedirectToAction("RemoveBannerError", "Errors");
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> WoWBanners()
        {
            try
            {
                var gameName = "WorldOfWarcraft";

                var bannersModels = await bannerService.GetBannersAsync(gameName);

                return View(bannersModels);
            }
            catch (Exception)
            {
                return RedirectToAction("BannerError", "Errors");
            }

        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> StarCraftBanners()
        {
            try
            {
                var gameName = "StarCraft";

                var bannersModels = await bannerService.GetBannersAsync(gameName);

                return View(bannersModels);
            }
            catch (Exception)
            {
                return RedirectToAction("BannerError", "Errors");
            }

        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> DiabloBanners()
        {
            try
            {
                var gameName = "Diablo";

                var bannersModels = await bannerService.GetBannersAsync(gameName);

                return View(bannersModels);
            }
            catch (Exception)
            {
                return RedirectToAction("BannerError", "Errors");
            }

        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GooglePlayBanners()
        {
            try
            {
                var gameName = "GooglePlay";

                var bannersModels = await bannerService.GetBannersAsync(gameName);

                return View(bannersModels);
            }
            catch (Exception)
            {
                return RedirectToAction("BannerError", "Errors");
            }

        }

    }
}
