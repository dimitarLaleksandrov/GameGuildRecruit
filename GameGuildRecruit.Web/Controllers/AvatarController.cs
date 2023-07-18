using GameGuildRecruit.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GameGuildRecruit.Web.ViewModels.Avatar;



namespace GameGuildRecruit.Web.Controllers
{
    public class AvatarController : BaseController
    {

        private readonly IAvatarService avatarService;

        private readonly IGuildRecruitUserService userService;



        public AvatarController(IAvatarService avatarService, IGuildRecruitUserService userService)
        {
            this.avatarService = avatarService;
            this.userService = userService;
        }



        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                var bannerModel = await avatarService.GetNewAvatarModelAsync();

                return View(bannerModel);
            }
            catch (Exception)
            {

                return RedirectToAction("CreateAndEditBannerError", "Errors");
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(Guid id, AvatarFormModel avatarModel)
        {
            if (!ModelState.IsValid)
            {
                return View(avatarModel);
            }

            try
            {
                await avatarService.AddAvatarAsync(avatarModel, id);

                return RedirectToAction("ChooseAvatar", "Avatar");
            }
            catch (Exception)
            {

                return RedirectToAction("CreateAndEditBannerError", "Errors");
            }

        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ChooseAvatar()
        {
            return View();
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> SelectAvatar()
        {

            var routeData = RouteData.Values.Values.ToArray();
            var pixId = routeData[2]!.ToString();

            var userName = this.User.Identity!.Name;

            try
            {
                var userModel = await userService.GetUserByUserNameAsync(userName!);
                if (userModel == null)
                {
                    return RedirectToAction("GetUsersError", "Errors");
                }

                await avatarService.SetUserAvatarAsync(userModel, pixId!);
                return RedirectToAction("Edit", "GuildUser");
            }
            catch (Exception)
            {
                return RedirectToAction("EmptyGuildInfo", "Errors");
            }
        }




    }
}
