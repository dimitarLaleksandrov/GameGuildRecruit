using GameGuildRecruit.Web.Data;
using GameGuildRecruit.Web.Services.Interfaces;
using GameGuildRecruit.Web.ViewModels.Game;
using Microsoft.EntityFrameworkCore;

namespace GameGuildRecruit.Web.Services
{
    public class HomeService : IHomeService
    {

        private readonly GameGuildRecruitDbContext dbContext;

        public HomeService(GameGuildRecruitDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        public async Task<IEnumerable<GameViewModel?>> GetGamesAsync()
        {
            return await dbContext.Games
                 .Where(g =>g.IsGameHasView == true)
                 .Select(g => new GameViewModel
                 {
                     Id = g.Id,
                     GameName = g.GameName,
                     GameSlideImageURL = g.GameSlideImageURL,
                     GameLogoImageURL = g.GameLogoImageURL,
                     IsGameHasView = g.IsGameHasView
                 })
                 .ToArrayAsync();
        }
    }
}
