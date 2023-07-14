using GameGuildRecruit.Web.Data;
using GameGuildRecruit.Web.Data.Models;
using GameGuildRecruit.Web.Services.Interfaces;
using GameGuildRecruit.Web.ViewModels.ContactPlayer;
using GameGuildRecruit.Web.ViewModels.Game;
using GameGuildRecruit.Web.ViewModels.GuildRecruitUser;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameGuildRecruit.Web.Services
{
    public class GameService : IGameService
    {

        private readonly GameGuildRecruitDbContext dbContext;

        public GameService(GameGuildRecruitDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<GameFormModel> GetNewGameModelAsync()
        {
            var gameModel = new GameFormModel
            {

            };

            return gameModel;
        }

        public async Task AddGameAsync(GameFormModel gameModel, Guid id)
        {
            var game = new Game()
            {
                Id = id,
                GameName = gameModel.GameName,
                GameSlideImageURL = gameModel.GameSlideImageURL,
                GameLogoImageURL = gameModel.GameLogoImageURL,
                IsGameHasView = gameModel.IsGameHasView

            };

            await dbContext.Games.AddAsync(game);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task <IEnumerable<GameViewModel?>> GetGamesAsync()
        {
            return await dbContext.Games
                 .Select(g => new GameViewModel
                 {
                     Id = g.Id,
                     GameName = g.GameName,
                     GameSlideImageURL= g.GameSlideImageURL,
                     GameLogoImageURL= g.GameLogoImageURL,
                     IsGameHasView = g.IsGameHasView
                 })
                 .ToArrayAsync();
        }

        public async Task GetGameIfViewIsCreateByIdAsync(Guid id)
        {
            var game = await dbContext.Games.FindAsync(id);

            if (game != null)
            {
                game.IsGameHasView = true;

                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<GameViewModel?> GetGameByIdAsync(Guid id)
        {
            return await dbContext.Games
               .Where(g => g.Id == id)
               .Select(gm => new GameViewModel
               {
                   Id = gm.Id,
                   GameName = gm.GameName,
                   GameLogoImageURL = gm.GameLogoImageURL,
                   GameSlideImageURL = gm.GameSlideImageURL,
                   IsGameHasView= gm.IsGameHasView
  
               })
               .FirstOrDefaultAsync();
        }

        public async Task RemoveGameAsync(GameViewModel game)
        {
            var gameToDelete = await dbContext.Games.Where(g => g.Id == game.Id)
                                                               .Select(x => new Game
                                                               {
                                                                   Id = x.Id,
                                                                   GameName = x.GameName,
                                                                   GameLogoImageURL = x.GameLogoImageURL,
                                                                   GameSlideImageURL = x.GameSlideImageURL,
                                                                   IsGameHasView = x.IsGameHasView

                                                               })
                                                               .FirstOrDefaultAsync();

            if (gameToDelete != null)
            {
                dbContext.Games.Remove(gameToDelete);

                await dbContext.SaveChangesAsync();
            }

        }
    }
}
