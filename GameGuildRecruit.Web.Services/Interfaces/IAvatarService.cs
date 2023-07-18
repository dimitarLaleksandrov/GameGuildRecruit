

using GameGuildRecruit.Web.ViewModels.GuildRecruitUser;

namespace GameGuildRecruit.Web.Services.Interfaces
{
    public interface IAvatarService
    {
        Task SetUserAvatarAsync(GuildRecruitUserFormModel userModel, string pixId);


    }
}
