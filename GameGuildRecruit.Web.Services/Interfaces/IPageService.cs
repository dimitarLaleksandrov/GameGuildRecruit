using GameGuildRecruit.Web.ViewModels.ContactPlayer;
using GameGuildRecruit.Web.ViewModels.GuildRecruitUser;


namespace GameGuildRecruit.Web.Services.Interfaces
{
    public interface IPageService
    {
        Task<GuildUsersPageServiceModel> GetAllUsersByGameNameAsync(GuildUsersQueryModel queryModel, string usersGameName);

        Task<IEnumerable<ContactPlayerViewModel>> GetUserContactsByIdAsync(Guid userId);

        Task<ContactPlayerFormModel?> GetContactForFeedbackByIdAsync(Guid id);

    }
}
