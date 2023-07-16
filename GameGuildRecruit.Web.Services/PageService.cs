using GameGuildRecruit.Web.Data;
using GameGuildRecruit.Web.Services.Interfaces;
using GameGuildRecruit.Web.ViewModels.ContactPlayer;
using GameGuildRecruit.Web.ViewModels.GuildRecruitUser;
using GameGuildRecruit.Web.Data.Models;
using Microsoft.EntityFrameworkCore;
using GameGuildRecruit.Web.ViewModels.Banner;


namespace GameGuildRecruit.Web.Services
{
    public class PageService : IPageService
    {
        private readonly GameGuildRecruitDbContext dbContext;


        public PageService(GameGuildRecruitDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        public async Task<GuildUsersPageServiceModel> GetAllUsersByGameNameAsync(GuildUsersQueryModel queryModel, string usersGameName)
        {
            IQueryable<GuildRecruitUser> guildUsersQuery = this.dbContext
               .GuildRecruitUsers
               .Where(u => u.GameName == usersGameName)
               .AsQueryable();

            IQueryable<Banner> bannerQuery = this.dbContext
             .Banners
             .Where(b => b.GameName == usersGameName)
             .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.GuildName))
            {
                guildUsersQuery = guildUsersQuery
                    .Where(g => g.GuildName == queryModel.GuildName);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";

                guildUsersQuery = guildUsersQuery
                    .Where(g => EF.Functions.Like(g.GuildName, wildCard));

            }

            IEnumerable<GuildRecruitUserFormModel> allGuildUsers = await guildUsersQuery
                .Skip((queryModel.CurrentPage - 1) * queryModel.UserPerPage)
                .Take(queryModel.UserPerPage)
                .Select(g => new GuildRecruitUserFormModel
                {
                    Id = g.Id,
                    NickName = g.NickName,
                    UrlLink = g.UrlLink,
                    GuildName = g.GuildName,
                    ServerName = g.ServerName,
                    GameName = g.GameName,
                    Description = g.Description,
                    UserName = g.UserName,
                    UserAvatarPix = g.UserAvatarPix,
                    UserContactNum = g.Contacts.Count()
                })
                .ToArrayAsync();

            IEnumerable<BannerFormModel> allBanners = await bannerQuery
              .Skip((queryModel.CurrentPage - 1) * queryModel.UserPerPage)
              .Take(queryModel.UserPerPage)
              .Select(b => new BannerFormModel
              {
                  Id = b.Id,
                  GameName = b.GameName,
                  BannerImageURL = b.BannerImageURL,
                  BannerTitle = b.BannerTitle,
                  BannerURL = b.BannerURL,
                  Description = b.Description
              })
              .ToArrayAsync();

            int guildUsersCount = guildUsersQuery.Count();
            int bannerCount = bannerQuery.Count();


            return new GuildUsersPageServiceModel()
            {
                GuildUsersCount = guildUsersCount,
                GuildUsers = allGuildUsers,
                BannerCount = bannerCount,
                Banners = allBanners
            };
  
        }

        public async Task<ContactPlayerFormModel?> GetContactForFeedbackByIdAsync(Guid id)
        {
            return await dbContext.ContactPlayers
               .Where(c => c.Id == id)
               .Select(p => new ContactPlayerFormModel
               {
                   Id = p.Id,
                   NickName = p.NickName,
                   Description = p.Description,
                   UrlLink = p.UrlLink,
                   Feedback = p.Feedback
               })
               .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ContactPlayerViewModel>> GetUserContactsByIdAsync(Guid userId)
        {
            return await dbContext.ContactPlayers
               .Where(x => x.UserId == userId)
               .Select(c => new ContactPlayerViewModel
               {
                   Id = c.Id,
                   NickName = c.NickName,
                   UrlLink = c.UrlLink,
                   Description = c.Description,
                   GuildName = c.GuildName,
                   UserId = c.UserId,
                   GameName = c.GameName,
                   ServerName = c.ServerName,
                   UserNickName = c.UserNickName,
                   Feedback = c.Feedback,
                   IsAccepted = c.IsAccepted,
               })
               .ToArrayAsync();
        }
    }
}
