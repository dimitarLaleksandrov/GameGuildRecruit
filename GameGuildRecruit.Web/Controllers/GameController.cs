using GameGuildRecruit.Web.Services;
using GameGuildRecruit.Web.Services.Interfaces;
using GameGuildRecruit.Web.ViewModels.Game;
using GameGuildRecruit.Web.ViewModels.GuildRecruitUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameGuildRecruit.Web.Controllers
{
    public class GameController : BaseController
    {

        private readonly IGameService gameService;

        private readonly IGuildRecruitUserService userService;

        private readonly IContactService contactService;


        public GameController(IGameService gameService, IGuildRecruitUserService userService, IContactService contactService)
        {
            this.gameService = gameService;
            this.userService = userService;
            this.contactService = contactService;
        }



        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ShowGames()
        {
            try
            {
                var gamesModels = await gameService.GetGamesAsync();

                return View(gamesModels);
            }
            catch (Exception)
            {
                return RedirectToAction("EmptyGuildInfo", "Errors");
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                var gameModel = await gameService.GetNewGameModelAsync();

                return View(gameModel);
            }
            catch (Exception)
            {

                return RedirectToAction("CreateAndEditError", "Errors");
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(Guid id, GameFormModel gameModel)
        {
            if (!ModelState.IsValid)
            {
                return View(gameModel);
            }

            try
            {
                await gameService.AddGameAsync(gameModel, id);

                return RedirectToAction("ShowGames", "Game");
            }
            catch (Exception)
            {

                return RedirectToAction("CreateAndEditError", "Errors");
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var gameModel = await gameService.GetGameForEditByIdAsync(id!);

                return View(gameModel);
            }
            catch (Exception)
            {

                return RedirectToAction("CreateAndEditError", "Errors");
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(GameFormModel gameModel)
        {
           
            try
            {
                await gameService.EditGameAsync(gameModel);

                return RedirectToAction("ShowGames", "Game");
            }
            catch (Exception)
            {

                return RedirectToAction("CreateAndEditError", "Errors");
            }
        }


        [Authorize]
        public async Task<IActionResult> GameViewMade(Guid id)
        {
            try
            {
                await gameService.GetGameIfViewIsCreateByIdAsync(id);

                return RedirectToAction("ShowGames", "Game");
            }
            catch (Exception)
            {
                return RedirectToAction("GetContactError", "Errors");
            }
        }


        [Authorize]
        public async Task<IActionResult> DeleteGame(Guid id)
        {
            var game = await gameService.GetGameByIdAsync(id);

            if (game == null)
            {
                return RedirectToAction("GetContactErrors", "Errors");
            }

            try
            {
                await gameService.RemoveGameAsync(game);

                return RedirectToAction("ShowGames", "Game");
            }
            catch (Exception)
            {
                return RedirectToAction("RemoveContactErrors", "Errors");
            }

        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GoToGame(Guid id)
        {
            var game = await gameService.GetGameByIdAsync(id);

            if (game == null)
            {
                return RedirectToAction("GetContactErrors", "Errors");
            }

            try
            {
                var gameName = game.GameName;
                return RedirectToAction(gameName, "Pages");
            }
            catch (Exception)
            {

                return RedirectToAction("CreateAndEditError", "Errors");
            }
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> RemoveGuild(Guid id)
        {
            var userModel = await contactService.GetUserByIdAsync(id);

            if (userModel == null)
            {
                return RedirectToAction("EmptyGuildInfo", "Errors");
            }

            try
            {
                await userService.RemoveGuildInfoAsync(userModel);

                return RedirectToAction("ShowGames", "Game");
            }
            catch (Exception)
            {

                return RedirectToAction("RemoveGuildInfoError", "Errors");
            }
        }


    }
}
