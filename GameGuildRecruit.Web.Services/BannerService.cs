using GameGuildRecruit.Web.Services.Interfaces;
using GameGuildRecruit.Web.ViewModels.Banner;
using GameGuildRecruit.Web.ViewModels.Game;
using GameGuildRecruit.Web.Data.Models;
using GameGuildRecruit.Web.Data;
using Microsoft.EntityFrameworkCore;

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

        public async Task EditBannerAsync(BannerFormModel bannerModel)
        {
            var findBannerById = await dbContext.Banners.Where(x => x.Id == bannerModel.Id).FirstOrDefaultAsync();

            if (findBannerById != null)
            {
                findBannerById.Id = bannerModel.Id;
                findBannerById.GameName = bannerModel.GameName;
                findBannerById.BannerImageURL = bannerModel.BannerImageURL;
                findBannerById.BannerTitle = bannerModel.BannerTitle;
                findBannerById.Description = bannerModel.Description;
                findBannerById.BannerURL = bannerModel.BannerURL;

                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<BannerFormModel?> GetBannerByIdAsync(Guid id)
        {
            return await dbContext.Banners
                .Where(x => x.Id == id)
                .Select(b => new BannerFormModel
                {
                    Id = b.Id,
                    GameName = b.GameName,
                    BannerImageURL = b.BannerImageURL,
                    BannerTitle = b.BannerTitle,
                    Description = b.Description,
                    BannerURL = b.BannerURL

                })
                .FirstOrDefaultAsync();
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
