using GameGuildRecruit.Web.Data;
using GameGuildRecruit.Web.Data.Models;
using GameGuildRecruit.Web.Services.Interfaces;
using GameGuildRecruit.Web.ViewModels.Game;

namespace GameGuildRecruit.Web.Services
{
    public class GameService : IGameService
    {

        private readonly GameGuildRecruitDbContext dbContext;

        public GameService(GameGuildRecruitDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddGameAsync(GameFormModel gameModel, Guid id)
        {
            var game = new Game()
            {
                Id = id,

                GameName = gameModel.GameName,
                GameSlideImageURL = gameModel.GameSlideImageURL,
                GameLogoImageURL = gameModel.GameLogoImageURL

            };

            await dbContext.Games.AddAsync(game);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<GameFormModel> GetNewGameModelAsync()
        {

            var gameModel = new GameFormModel
            {
                
            };

            return gameModel;
        }




    }
}
