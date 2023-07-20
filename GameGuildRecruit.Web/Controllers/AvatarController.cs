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
        public async Task<IActionResult> CreateAvatar(Guid id, AvatarFormModel avatarModel)
        {
            if (!ModelState.IsValid)
            {
                return View(avatarModel);
            }

            try
            {
                await avatarService.AddAvatarAsync(avatarModel, id);

                return RedirectToAction("EditAvatars", "Avatar");
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
                var avatar = await avatarService.GetAvatarByIdAsync(id);

                return View(avatar);
            }
            catch (Exception)
            {

                return RedirectToAction("CreateAndEditBannerError", "Errors");
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditAvatar(AvatarFormModel avatarModel)
        {
            if (!ModelState.IsValid)
            {
                return View(avatarModel);
            }

            try
            {
                await avatarService.EditAvatarAsync(avatarModel);

                return RedirectToAction("EditAvatars", "Avatar");
            }
            catch (Exception)
            {

                return RedirectToAction("CreateAndEditBannerError", "Errors");
            }
        }


        [Authorize]
        public async Task<IActionResult> RemoveAvatar(Guid id)
        {
            try
            {
                await avatarService.RemoveAvatarAsync(id);

                return RedirectToAction("EditAvatars", "Avatar");
            }
            catch (Exception)
            {

                return RedirectToAction("RemoveBannerError", "Errors");
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Avatars()
        {
            try
            {
                var avatarsModels = await avatarService.GetAvatarsAsync();

                return View(avatarsModels);
            }
            catch (Exception)
            {
                return RedirectToAction("BannerError", "Errors");
            }

        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> EditAvatars()
        {
            try
            {
                var avatarsModels = await avatarService.GetAvatarsAsync();

                return View(avatarsModels);
            }
            catch (Exception)
            {
                return RedirectToAction("BannerError", "Errors");
            }

        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> SelectAvatar(Guid id)
        {

            //var routeData = RouteData.Values.Values.ToArray();
            //var pixId = routeData[2]!.ToString();

            var avatarId = id;
            var userName = this.User.Identity!.Name;

            try
            {
                var userModel = await userService.GetUserByUserNameAsync(userName!);
                if (userModel == null)
                {
                    return RedirectToAction("GetUsersError", "Errors");
                }

                var avatarModel = await avatarService.GetAvatarForSelectByIdAsync(avatarId!);
                if (avatarModel == null)
                {
                    return RedirectToAction("GetUsersError", "Errors");
                }

                await avatarService.SetUserAvatarAsync(userModel, avatarModel.AvatarPixURL);
                return RedirectToAction("Edit", "GuildUser");
            }
            catch (Exception)
            {
                return RedirectToAction("EmptyGuildInfo", "Errors");
            }
        }




    }
}
