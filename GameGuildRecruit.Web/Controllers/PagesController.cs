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
            var usersGameName = "StarCraft";

            try
            {
                GuildUsersPageServiceModel usersWhitTheSameGame = await pageService.GetAllUsersByGameNameAsync(queryModel, usersGameName);

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

            return RedirectToAction("StarCraftPage", "Pages");
        }


        [HttpGet]
        public async Task<IActionResult> WorldOfWarcraft([FromQuery] GuildUsersQueryModel queryModel)
        {
            var usersGameName = "WorldOfWarcraft";

            try
            {
                GuildUsersPageServiceModel usersWhitTheSameGame = await pageService.GetAllUsersByGameNameAsync(queryModel, usersGameName);

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

            return RedirectToAction("WoWPage", "Pages");
        }


        [HttpGet]
        public async Task<IActionResult> Diablo([FromQuery] GuildUsersQueryModel queryModel)
        {
            var usersGameName = "Diablo";
            try
            {
                GuildUsersPageServiceModel usersWhitTheSameGame = await pageService.GetAllUsersByGameNameAsync(queryModel, usersGameName);

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

            return RedirectToAction("DiabloPage", "Pages");
        }


        [HttpGet]
        public async Task<IActionResult> GooglePlay([FromQuery] GuildUsersQueryModel queryModel)
        {
            var usersGameName = "GooglePlay";
            try
            {
                GuildUsersPageServiceModel usersWhitTheSameGame = await pageService.GetAllUsersByGameNameAsync(queryModel, usersGameName);

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

            return RedirectToAction("GooglePlayPage", "Pages");
        }

    }
}
