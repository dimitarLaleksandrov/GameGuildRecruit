

using GameGuildRecruit.Web.ViewModels.Game;

namespace GameGuildRecruit.Web.Services.Interfaces
{
    public interface IHomeService
    {
        Task<IEnumerable<GameViewModel?>> GetGamesAsync();

    }
}
