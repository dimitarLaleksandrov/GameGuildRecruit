using GameGuildRecruit.Web.ViewModels.ContactPlayer;
using GameGuildRecruit.Web.ViewModels.GuildRecruitUser;


namespace GameGuildRecruit.Web.Services.Interfaces
{
    public interface IGuildRecruitUserService
    {
        Task<GuildRecruitUserViewModel?> GetUserByUserNameAsync(string userName);

        Task<GuildRecruitUserFormModel?> GetUserByUserNameFormModelAsync(string userName);


        Task<GuildRecruitUserFormModel> GetNewUserModelAsync();

        Task AddUserAsync(GuildRecruitUserFormModel userModel, string userName, Guid id);

        Task EditUserAsync(GuildRecruitUserFormModel userModel, string userName);

        Task<GuildUsersPageServiceModel> GetUsersWithTheSameGameAsync(GuildUsersQueryModel queryModel, string gameName);

        Task<GuildRecruitUserFormModel?> GetUserByUserNameForIdAsync(string userName);

        Task<IEnumerable<ContactPlayerViewModel>> GetMyContactsByIdAsync(Guid userId);

        Task GetContactForAcceptByIdAsync(Guid id);

        Task GetContactForRejectedByIdAsync(Guid id);

        Task RemoveGuildInfoAsync(GuildRecruitUserViewModel userModel);

    }
}
