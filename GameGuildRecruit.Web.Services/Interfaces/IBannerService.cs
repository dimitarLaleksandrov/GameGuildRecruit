

using GameGuildRecruit.Web.ViewModels.Banner;
using GameGuildRecruit.Web.ViewModels.Game;
using GameGuildRecruit.Web.ViewModels.GuildRecruitUser;

namespace GameGuildRecruit.Web.Services.Interfaces
{
    public interface IBannerService
    {

        Task<BannerFormModel> GetNewBannerModelAsync();

        Task AddBannerAsync(BannerFormModel bannerModel, Guid id);

        Task<BannerFormModel?> GetBannerByIdAsync(Guid id);

        Task EditBannerAsync(BannerFormModel userModel);

        Task RemoveBannerAsync(Guid id);

        Task<IEnumerable<BannerFormModel>> GetBannersAsync(string gameName);


    }
}
