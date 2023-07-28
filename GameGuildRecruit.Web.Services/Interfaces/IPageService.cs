using GameGuildRecruit.Web.ViewModels.Banner;
using GameGuildRecruit.Web.ViewModels.ContactPlayer;
using GameGuildRecruit.Web.ViewModels.Game;
using GameGuildRecruit.Web.ViewModels.GuildRecruitUser;


namespace GameGuildRecruit.Web.Services.Interfaces
{
    public interface IPageService
    {
        Task<GuildUsersPageServiceModel> GetAllUsersByGameNameAsync(GuildUsersQueryModel queryModel, string gameName);

        Task<IEnumerable<ContactPlayerViewModel>> GetUserContactsByIdAsync(Guid userId);

        Task<ContactPlayerFormModel?> GetBannersAsync(Guid id);

        Task<GameViewModel?> GetGameByNameAsync(string gameName);


    }
}
