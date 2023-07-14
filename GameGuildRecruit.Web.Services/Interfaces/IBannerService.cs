

using GameGuildRecruit.Web.ViewModels.Banner;
using GameGuildRecruit.Web.ViewModels.Game;

namespace GameGuildRecruit.Web.Services.Interfaces
{
    public interface IBannerService
    {

        Task<BannerFormModel> GetNewBannerModelAsync();

        Task AddBannerAsync(BannerFormModel bannerModel, Guid id);

    }
}
