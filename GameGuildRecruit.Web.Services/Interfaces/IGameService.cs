
using GameGuildRecruit.Web.ViewModels.Game;


namespace GameGuildRecruit.Web.Services.Interfaces
{
    public interface IGameService
    {
        Task<GameFormModel> GetNewGameModelAsync();

        Task AddGameAsync(GameFormModel userModel, Guid id);

    }
}
