

using GameGuildRecruit.Web.ViewModels.Avatar;
using GameGuildRecruit.Web.ViewModels.Banner;
using GameGuildRecruit.Web.ViewModels.GuildRecruitUser;

namespace GameGuildRecruit.Web.Services.Interfaces
{
    public interface IAvatarService
    {
        Task<AvatarFormModel> GetNewAvatarModelAsync();

        Task AddAvatarAsync(AvatarFormModel avatarModel, Guid id);

        Task<IEnumerable<AvatarFormModel>> GetAvatarsAsync();

        Task<AvatarFormModel?> GetAvatarByIdAsync(Guid id);

        Task EditAvatarAsync(AvatarFormModel avatarModel);

        Task RemoveAvatarAsync(Guid id);


        Task SetUserAvatarAsync(GuildRecruitUserFormModel userModel, string avatarPixURL);

       

    }
}
