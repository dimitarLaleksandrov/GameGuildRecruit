﻿using GameGuildRecruit.Web.Services.Interfaces;
using GameGuildRecruit.Web.ViewModels.GuildRecruitUser;
using Microsoft.AspNetCore.Mvc;

namespace GameGuildRecruit.Web.Controllers
{
    public class PagesController : BaseController
    {

        private readonly IPageService pageService;

        public PagesController(IPageService pageService)
        {
            this.pageService = pageService;

        }




        [HttpGet]
        public async Task<IActionResult> StarCraft([FromQuery] GuildUsersQueryModel queryModel)
        {
            var usersGameName = "StarCraft";

            GuildUsersPageServiceModel usersWhitTheSameGame = await pageService.GetAllUsersByGameNameAsync(queryModel, usersGameName);

            queryModel.GuildUsers = usersWhitTheSameGame.GuildUsers;
            queryModel.GuildUsersCount = usersWhitTheSameGame.GuildUsersCount;

            return View(queryModel);

        }

        [HttpPost]
        public async Task<IActionResult> StarCraftContacts(Guid id)
        {
            var contactsModels = await pageService.GetUserContactsByIdAsync(id);

            return View(contactsModels);
        }

        [HttpPost]
        public async Task<IActionResult> StarCraftGetContactFeedback(Guid id)
        {
            var userModel = await pageService.GetContactForFeedbackByIdAsync(id);

            return View(userModel);
        }

        public async Task<IActionResult> StarCraftPreviousPage()
        {

            return RedirectToAction("StarCraftPage", "Pages");
        }


        [HttpGet]
        public async Task<IActionResult> WorldOfWarcraft([FromQuery] GuildUsersQueryModel queryModel)
        {
            var usersGameName = "WorldOfWarcraft";

            GuildUsersPageServiceModel usersWhitTheSameGame = await pageService.GetAllUsersByGameNameAsync(queryModel, usersGameName);

            queryModel.GuildUsers = usersWhitTheSameGame.GuildUsers;
            queryModel.GuildUsersCount = usersWhitTheSameGame.GuildUsersCount;

            return View(queryModel);
        }

        [HttpPost]
        public async Task<IActionResult> WoWContacts(Guid id)
        {
            var contactsModels = await pageService.GetUserContactsByIdAsync(id);

            return View(contactsModels);
        }

        [HttpPost]
        public async Task<IActionResult> WoWGetContactFeedback(Guid id)
        {
            var userModel = await pageService.GetContactForFeedbackByIdAsync(id);

            return View(userModel);
        }

        public async Task<IActionResult> WoWPreviousPage()
        {

            return RedirectToAction("WoWPage", "Pages");
        }


        [HttpGet]
        public async Task<IActionResult> Diablo([FromQuery] GuildUsersQueryModel queryModel)
        {
            var usersGameName = "Diablo";

            GuildUsersPageServiceModel usersWhitTheSameGame = await pageService.GetAllUsersByGameNameAsync(queryModel, usersGameName);

            queryModel.GuildUsers = usersWhitTheSameGame.GuildUsers;
            queryModel.GuildUsersCount = usersWhitTheSameGame.GuildUsersCount;

            return View(queryModel);
        }

        [HttpPost]
        public async Task<IActionResult> DiabloContacts(Guid id)
        {

            var contactsModels = await pageService.GetUserContactsByIdAsync(id);

            return View(contactsModels);
        }

        [HttpPost]
        public async Task<IActionResult> DiabloGetContactFeedback(Guid id)
        {
            var userModel = await pageService.GetContactForFeedbackByIdAsync(id);

            return View(userModel);
        }

        public async Task<IActionResult> DiabloPreviousPage()
        {

            return RedirectToAction("DiabloPage", "Pages");
        }


        [HttpGet]
        public async Task<IActionResult> GooglePlay([FromQuery] GuildUsersQueryModel queryModel)
        {
            var usersGameName = "GooglePlay";

            GuildUsersPageServiceModel usersWhitTheSameGame = await pageService.GetAllUsersByGameNameAsync(queryModel, usersGameName);

            queryModel.GuildUsers = usersWhitTheSameGame.GuildUsers;
            queryModel.GuildUsersCount = usersWhitTheSameGame.GuildUsersCount;

            return View(queryModel);
        }

        [HttpPost]
        public async Task<IActionResult> GooglePlayContacts(Guid id)
        {

            var contactsModels = await pageService.GetUserContactsByIdAsync(id);

            return View(contactsModels);
        }

        [HttpPost]
        public async Task<IActionResult> GooglePlayGetContactFeedback(Guid id)
        {
            var userModel = await pageService.GetContactForFeedbackByIdAsync(id);

            return View(userModel);
        }

        public async Task<IActionResult> GooglePlayPreviousPage()
        {

            return RedirectToAction("GooglePlayPage", "Pages");
        }

    }
}
