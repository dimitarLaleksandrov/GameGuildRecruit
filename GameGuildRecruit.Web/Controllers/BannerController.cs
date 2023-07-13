using GameGuildRecruit.Web.Services.Interfaces;
using GameGuildRecruit.Web.ViewModels.GuildRecruitUser;
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
                var userName = this.User.Identity!.Name;

                var userGuildExist = await userService.GetUserByUserNameAsync(userName!);

                if (userGuildExist != null)
                {
                    if (userGuildExist.UserName == userName)
                    {
                        return RedirectToAction("Edit", "GuildUser");
                    }
                }

                var userModel = await userService.GetNewUserModelAsync();

                return View(userModel);
            }
            catch (Exception)
            {

                return RedirectToAction("CreateAndEditError", "Errors");
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(Guid id, GuildRecruitUserFormModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userModel);
            }

            try
            {
                var userName = this.User.Identity!.Name;

                await userService.AddUserAsync(userModel, userName!, id);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {

                return RedirectToAction("CreateAndEditError", "Errors");
            }
        }
    }
}
