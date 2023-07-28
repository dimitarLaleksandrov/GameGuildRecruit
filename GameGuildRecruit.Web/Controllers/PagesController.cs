using GameGuildRecruit.Web.Common.Enums;
using GameGuildRecruit.Web.Services.Interfaces;
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
            var gameName = "StarCraft";

            var gamePage = await pageService.GetGameByNameAsync(gameName);

            if(gamePage == null) 
            {
                return RedirectToAction("PageError", "Errors");
            }

            if(gamePage.IsGameHasView == false) 
            {
                return RedirectToAction("PageError", "Errors");
            }

            try
            {
                GuildUsersPageServiceModel usersWhitTheSameGame = await pageService.GetAllUsersByGameNameAsync(queryModel, gameName);

                queryModel.GuildUsers = usersWhitTheSameGame.GuildUsers;
                queryModel.GuildUsersCount = usersWhitTheSameGame.GuildUsersCount;
                queryModel.Banners = usersWhitTheSameGame.Banners;
                queryModel.BannerCount = usersWhitTheSameGame.BannerCount;

                return View(queryModel);
            }
            catch (Exception)
            {
                return RedirectToAction("PageError", "Errors");
            }

        }

        [HttpPost]
        public async Task<IActionResult> StarCraftContacts(Guid id)
        {
            var gameName = "StarCraft";

            var gamePage = await pageService.GetGameByNameAsync(gameName);

            if (gamePage == null)
            {
                return RedirectToAction("PageError", "Errors");
            }

            if (gamePage.IsGameHasView == false)
            {
                return RedirectToAction("PageError", "Errors");
            }

            try
            {
                var contactsModels = await pageService.GetUserContactsByIdAsync(id);

                return View(contactsModels);
            }
            catch (Exception)
            {
                return RedirectToAction("GetContactError", "Errors");
            }
           
        }

        [HttpPost]
        public async Task<IActionResult> StarCraftGetContactFeedback(Guid id)
        {
            var gameName = "StarCraft";

            var gamePage = await pageService.GetGameByNameAsync(gameName);

            if (gamePage == null)
            {
                return RedirectToAction("PageError", "Errors");
            }

            if (gamePage.IsGameHasView == false)
            {
                return RedirectToAction("PageError", "Errors");
            }

            try
            {
                var contactModel = await pageService.GetBannersAsync(id);

                return View(contactModel);
            }
            catch (Exception)
            {
                return RedirectToAction("GetContactError", "Errors");
            }
          
        }

        public async Task<IActionResult> StarCraftPreviousPage()
        {

            return RedirectToAction("StarCraft", "Pages");
        }


        [HttpGet]
        public async Task<IActionResult> WorldOfWarcraft([FromQuery] GuildUsersQueryModel queryModel)
        {
            var gameName = "WorldOfWarcraft";

            var gamePage = await pageService.GetGameByNameAsync(gameName);

            if (gamePage == null)
            {
                return RedirectToAction("PageError", "Errors");
            }

            if (gamePage.IsGameHasView == false)
            {
                return RedirectToAction("PageError", "Errors");
            }

            try
            {
                GuildUsersPageServiceModel usersWhitTheSameGame = await pageService.GetAllUsersByGameNameAsync(queryModel, gameName);

                queryModel.GuildUsers = usersWhitTheSameGame.GuildUsers;
                queryModel.GuildUsersCount = usersWhitTheSameGame.GuildUsersCount;
                queryModel.Banners = usersWhitTheSameGame.Banners;
                queryModel.BannerCount = usersWhitTheSameGame.BannerCount;

                return View(queryModel);
            }
            catch (Exception)
            {

                return RedirectToAction("PageError", "Errors");
            }       
        }

        [HttpPost]
        public async Task<IActionResult> WoWContacts(Guid id)
        {
            var gameName = "WorldOfWarcraft";

            var gamePage = await pageService.GetGameByNameAsync(gameName);

            if (gamePage == null)
            {
                return RedirectToAction("PageError", "Errors");
            }

            if (gamePage.IsGameHasView == false)
            {
                return RedirectToAction("PageError", "Errors");
            }

            try
            {
                var contactsModels = await pageService.GetUserContactsByIdAsync(id);

                return View(contactsModels);
            }
            catch (Exception)
            {
                return RedirectToAction("GetContactError", "Errors");
            }
        }

        [HttpPost]
        public async Task<IActionResult> WoWGetContactFeedback(Guid id)
        {
            var gameName = "WorldOfWarcraft";

            var gamePage = await pageService.GetGameByNameAsync(gameName);

            if (gamePage == null)
            {
                return RedirectToAction("PageError", "Errors");
            }

            if (gamePage.IsGameHasView == false)
            {
                return RedirectToAction("PageError", "Errors");
            }

            try
            {
                var contactsModels = await pageService.GetBannersAsync(id);

                return View(contactsModels); 
            }
            catch (Exception)
            {
                return RedirectToAction("GetContactError", "Errors");
            }
        }

        public async Task<IActionResult> WoWPreviousPage()
        {

            return RedirectToAction("WorldOfWarcraft", "Pages");
        }


        [HttpGet]
        public async Task<IActionResult> Diablo([FromQuery] GuildUsersQueryModel queryModel)
        {
            var gameName = "Diablo";

            var gamePage = await pageService.GetGameByNameAsync(gameName);

            if (gamePage == null)
            {
                return RedirectToAction("PageError", "Errors");
            }

            if (gamePage.IsGameHasView == false)
            {
                return RedirectToAction("PageError", "Errors");
            }

            try
            {
                GuildUsersPageServiceModel usersWhitTheSameGame = await pageService.GetAllUsersByGameNameAsync(queryModel, gameName);

                queryModel.GuildUsers = usersWhitTheSameGame.GuildUsers;
                queryModel.GuildUsersCount = usersWhitTheSameGame.GuildUsersCount;
                queryModel.Banners = usersWhitTheSameGame.Banners;
                queryModel.BannerCount = usersWhitTheSameGame.BannerCount;

                return View(queryModel);
            }
            catch (Exception)
            {
                return RedirectToAction("PageError", "Errors");
            }
        }

        [HttpPost]
        public async Task<IActionResult> DiabloContacts(Guid id)
        {
            var gameName = "Diablo";

            var gamePage = await pageService.GetGameByNameAsync(gameName);

            if (gamePage == null)
            {
                return RedirectToAction("PageError", "Errors");
            }

            if (gamePage.IsGameHasView == false)
            {
                return RedirectToAction("PageError", "Errors");
            }

            try
            {
                var contactsModels = await pageService.GetUserContactsByIdAsync(id);

                return View(contactsModels);
            }
            catch (Exception)
            {
                return RedirectToAction("GetContactError", "Errors");
            }
        }

        [HttpPost]
        public async Task<IActionResult> DiabloGetContactFeedback(Guid id)
        {
            var gameName = "Diablo";

            var gamePage = await pageService.GetGameByNameAsync(gameName);

            if (gamePage == null)
            {
                return RedirectToAction("PageError", "Errors");
            }

            if (gamePage.IsGameHasView == false)
            {
                return RedirectToAction("PageError", "Errors");
            }

            try
            {
                var contactsModels = await pageService.GetBannersAsync(id);

                return View(contactsModels);
            }
            catch (Exception)
            {
                return RedirectToAction("GetContactError", "Errors");
            }
        }

        public async Task<IActionResult> DiabloPreviousPage()
        {

            return RedirectToAction("Diablo", "Pages");
        }


        [HttpGet]
        public async Task<IActionResult> GooglePlay([FromQuery] GuildUsersQueryModel queryModel)
        {
            var gameName = "GooglePlay";

            var gamePage = await pageService.GetGameByNameAsync(gameName);

            if (gamePage == null)
            {
                return RedirectToAction("PageError", "Errors");
            }

            if (gamePage.IsGameHasView == false)
            {
                return RedirectToAction("PageError", "Errors");
            }

            try
            {
                GuildUsersPageServiceModel usersWhitTheSameGame = await pageService.GetAllUsersByGameNameAsync(queryModel, gameName);

                queryModel.GuildUsers = usersWhitTheSameGame.GuildUsers;
                queryModel.GuildUsersCount = usersWhitTheSameGame.GuildUsersCount;
                queryModel.Banners = usersWhitTheSameGame.Banners;
                queryModel.BannerCount = usersWhitTheSameGame.BannerCount;

                return View(queryModel);
            }
            catch (Exception)
            {
                return RedirectToAction("PageError", "Errors");
            }
        }

        [HttpPost]
        public async Task<IActionResult> GooglePlayContacts(Guid id)
        {
            var gameName = "GooglePlay";

            var gamePage = await pageService.GetGameByNameAsync(gameName);

            if (gamePage == null)
            {
                return RedirectToAction("PageError", "Errors");
            }

            if (gamePage.IsGameHasView == false)
            {
                return RedirectToAction("PageError", "Errors");
            }

            try
            {
                var contactsModels = await pageService.GetUserContactsByIdAsync(id);

                return View(contactsModels);
            }
            catch (Exception)
            {
                return RedirectToAction("GetContactError", "Errors");
            }
        }

        [HttpPost]
        public async Task<IActionResult> GooglePlayGetContactFeedback(Guid id)
        {
            var gameName = "GooglePlay";

            var gamePage = await pageService.GetGameByNameAsync(gameName);

            if (gamePage == null)
            {
                return RedirectToAction("PageError", "Errors");
            }

            if (gamePage.IsGameHasView == false)
            {
                return RedirectToAction("PageError", "Errors");
            }

            try
            {
                var contactsModels = await pageService.GetBannersAsync(id);

                return View(contactsModels);
            }
            catch (Exception)
            {
                return RedirectToAction("GetContactError", "Errors");
            }
        }

        public async Task<IActionResult> GooglePlayPreviousPage()
        {

            return RedirectToAction("GooglePlay", "Pages");
        }

    }
}
