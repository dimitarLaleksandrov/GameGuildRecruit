using GameGuildRecruit.Web.Data;
using GameGuildRecruit.Web.Data.Models;
using GameGuildRecruit.Web.Services.Interfaces;
using GameGuildRecruit.Web.ViewModels.Game;
using GameGuildRecruit.Web.ViewModels.GuildRecruitUser;
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
                 .Select(b => new GameViewModel
                 {
                     Id = b.Id,
                     GameName = b.GameName,
                     GameSlideImageURL= b.GameSlideImageURL,
                     GameLogoImageURL= b.GameLogoImageURL,
                     IsGameHasView = b.IsGameHasView
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


    }
}
