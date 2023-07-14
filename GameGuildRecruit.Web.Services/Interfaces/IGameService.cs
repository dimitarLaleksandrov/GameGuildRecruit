
using GameGuildRecruit.Web.ViewModels.ContactPlayer;
using GameGuildRecruit.Web.ViewModels.Game;


namespace GameGuildRecruit.Web.Services.Interfaces
{
    public interface IGameService
    {
        Task<GameFormModel> GetNewGameModelAsync();

        Task AddGameAsync(GameFormModel gameModel, Guid id);

        Task <IEnumerable<GameViewModel?>> GetGamesAsync();

        Task GetGameIfViewIsCreateByIdAsync(Guid id);

        Task<GameViewModel?> GetGameByIdAsync(Guid id);

        Task RemoveGameAsync(GameViewModel game);


    }
}
