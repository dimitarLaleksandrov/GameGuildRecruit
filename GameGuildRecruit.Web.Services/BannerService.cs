using GameGuildRecruit.Web.Services.Interfaces;
using GameGuildRecruit.Web.ViewModels.Banner;
using GameGuildRecruit.Web.ViewModels.Game;
using GameGuildRecruit.Web.Data.Models;
using GameGuildRecruit.Web.Data;



namespace GameGuildRecruit.Web.Services
{
    public class BannerService : IBannerService
    {

        private readonly GameGuildRecruitDbContext dbContext;

        public BannerService(GameGuildRecruitDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        public async Task AddBannerAsync(BannerFormModel bannerModel, Guid id)
        {
            var banner = new Banner()
            {
                Id = id,
                GameName = bannerModel.GameName,
                BannerImageURL = bannerModel.BannerImageURL,
                BannerTitle = bannerModel.BannerTitle,
                Description = bannerModel.Description,
                BannerURL = bannerModel.BannerURL
            };

            await dbContext.Banners.AddAsync(banner);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<BannerFormModel> GetNewBannerModelAsync()
        {

            var bannerModel = new BannerFormModel
            {

            };

            return bannerModel;
        }
    }
}
