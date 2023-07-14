﻿using GameGuildRecruit.Web.Services.Interfaces;
using GameGuildRecruit.Web.ViewModels.Game;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameGuildRecruit.Web.Controllers
{
    public class GameController : BaseController
    {

        private readonly IGameService gameService;


        public GameController(IGameService gameService)
        {
            this.gameService = gameService;

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
        public async Task<IActionResult> GameViewMade(Guid id)
        {
            try
            {
                await gameService.GetGameIfViewIsCreateByIdAsync(id);

                return RedirectToAction("MyContacts", "GuildUser");
            }
            catch (Exception)
            {
                return RedirectToAction("GetContactError", "Errors");
            }
        }
    }
}
