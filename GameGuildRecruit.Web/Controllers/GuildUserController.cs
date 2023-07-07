﻿using GameGuildRecruit.Web.Services;
using GameGuildRecruit.Web.Services.Interfaces;
using GameGuildRecruit.Web.ViewModels.GuildRecruitUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameGuildRecruit.Web.Controllers
{
    public class GuildUserController : BaseController
    {
        private readonly IGuildRecruitUser userService;


        public GuildUserController(IGuildRecruitUser userService)
        {
            this.userService = userService;

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
                        return RedirectToAction("Edit", "Errors");
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
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(userModel);
                }

                var userName = this.User.Identity!.Name;

                await userService.AddUserAsync(userModel, userName!, id);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {

                return RedirectToAction("CreateAndEditError", "Errors");
            }
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            try
            {
                var userName = this.User.Identity!.Name;

                var user = await userService.GetUserByUserNameAsync(userName!);

                return View(user);
            }
            catch (Exception)
            {

                return RedirectToAction("CreateAndEditError", "Errors");
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(GuildRecruitUserFormModel userModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(userModel);
                }

                var userName = this.User.Identity!.Name;

                await userService.EditUserAsync(userModel, userName!);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {

                return RedirectToAction("CreateAndEditError", "Errors");
            }

        }

        [Authorize]
        [HttpGet]

        public async Task<IActionResult> MyContacts()
        {
            var userName = this.User.Identity!.Name;

            var user = await userService.GetUserByUserNameForIdAsync(userName!);

            if(user == null)
            {
                return RedirectToAction("EmptyGuildInfo", "Errors");
            }

            var contactsModels = await userService.GetMyContactsByIdAsync(user.Id);

            return View(contactsModels);

        }

        [Authorize]
        public async Task<IActionResult> AcceptContact(Guid id)
        {
            await userService.GetContactForAcceptByIdAsync(id);

            return RedirectToAction("MyContacts", "GuildUser");
        }

        [Authorize]
        public async Task<IActionResult> RejectedContact(Guid id)
        {
            await userService.GetContactForRejectedByIdAsync(id);

            return RedirectToAction("MyContacts", "GuildUser");
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult>ChooseAvatar()
        {
            return View();
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> SelectAvatar()
        {          
            try
            {
                var routeData = RouteData.Values.Values.ToArray();
                var pixId = routeData[2]!.ToString();

                var userName = this.User.Identity!.Name;

                var userModel = await userService.GetUserByUserNameAsync(userName!);
                await userService.SetUserAvatarAsync(userModel, pixId!);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return RedirectToAction("EmptyGuildInfo", "Errors");
            }                  
        }

        [Authorize]
        public async Task<IActionResult> SetAvatar()
        {
            var userName = this.User.Identity!.Name;
            var userModel = await userService.GetUserByUserNameAsync(userName!);

            var userAvatarPix = userModel!.UserAvatarPix;


            return View(userAvatarPix);

        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ResetGuildInfo()
        {
            var userName = this.User.Identity!.Name;

            var userModel = await userService.GetUserByUserNameAsync(userName!);

            if (userModel ==null)
            {
                return RedirectToAction("Index", "Home");
            }

            await userService.RemoveGuildInfoAsync(userModel);

            return RedirectToAction("MyContacts", "GuildUser");
        }


        [Authorize]
        public async Task<IActionResult> ResetGuildInfoAcceptance()
        {
            return View();
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> UsersWithTheSameGame([FromQuery] GuildUsersQueryModel queryModel)
        {
            var userName = this.User.Identity!.Name;

            var user = await userService.GetUserByUserNameAsync(userName!);

            if (user == null)
            {
                return RedirectToAction("EmptyGuildInfo", "Errors");
            }

            GuildUsersPageServiceModel usersWhitTheSameGame = await userService.GetUsersWithTheSameGameAsync(queryModel, user.GameName);

            queryModel.GuildUsers = usersWhitTheSameGame.GuildUsers;
            queryModel.GuildUsersCount = usersWhitTheSameGame.GuildUsersCount;

            return View(queryModel);
        }

    }
}
