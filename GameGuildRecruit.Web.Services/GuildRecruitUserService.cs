using GameGuildRecruit.Web.Services.Interfaces;
using GameGuildRecruit.Web.ViewModels.ContactPlayer;
using GameGuildRecruit.Web.ViewModels.GuildRecruitUser;
using GameGuildRecruit.Web.Data;
using GameGuildRecruit.Web.Data.Models;


using Microsoft.EntityFrameworkCore;
using GameGuildRecruit.Web.ViewModels.Banner;

namespace GameGuildRecruit.Web.Services
{
    public class GuildRecruitUserService : IGuildRecruitUserService
    {

        private readonly GameGuildRecruitDbContext dbContext;

        public GuildRecruitUserService(GameGuildRecruitDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<GuildRecruitUserFormModel> GetNewUserModelAsync()
        {
            var contact = await dbContext.ContactPlayers
                                          .Select(p => new ContactPlayerViewModel
                                          {
                                              Id = p.Id,
                                              NickName = p.NickName,
                                              Description = p.Description,
                                              UrlLink = p.UrlLink,
                                              UserId = p.UserId,
                                              UserNickName = p.UserNickName,
                                              GameName = p.GameName,
                                              GuildName = p.GuildName,
                                              ServerName = p.ServerName,
                                              Feedback = p.Feedback,
                                              IsAccepted = p.IsAccepted
                                          })
                                          .ToArrayAsync();

            var userModel = new GuildRecruitUserFormModel
            {
                Contacts = contact
            };

            return userModel;
        }

        public async Task AddUserAsync(GuildRecruitUserFormModel userModel, string userName, Guid id)
        {

            GuildRecruitUser user = new GuildRecruitUser()
            {
                Id = id,
                NickName = userModel.NickName,
                UrlLink = userModel.UrlLink,
                GuildName = userModel.GuildName,
                ServerName = userModel.ServerName,
                GameName = userModel.GameName,
                Description = userModel.Description,
                UserName = userName,
                UserAvatarPix = userModel.UserAvatarPix
            };

            await dbContext.GuildRecruitUsers.AddAsync(user);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<GuildRecruitUserFormModel?> GetUserByUserNameAsync(string userName)
        {

            return await dbContext.GuildRecruitUsers
                 .Where(x => x.UserName == userName)
                 .Select(b => new GuildRecruitUserFormModel
                 {
                     Id = b.Id,
                     NickName = b.NickName,
                     UrlLink = b.UrlLink,
                     GuildName = b.GuildName,
                     ServerName = b.ServerName,
                     GameName = b.GameName,
                     Description = b.Description,
                     UserName = b.UserName,
                     UserAvatarPix = b.UserAvatarPix

                 })
                 .FirstOrDefaultAsync();
        }

        public async Task EditUserAsync(GuildRecruitUserFormModel userModel, string userName)
        {
            var findUserByUserName = await dbContext.GuildRecruitUsers.Where(x => x.UserName == userName).FirstOrDefaultAsync();

            if (findUserByUserName != null)
            {
                findUserByUserName.NickName = userModel.NickName;
                findUserByUserName.GuildName = userModel.GuildName;
                findUserByUserName.UrlLink = userModel.UrlLink;
                findUserByUserName.ServerName = userModel.ServerName;
                findUserByUserName.GameName = userModel.GameName;
                findUserByUserName.Description = userModel.Description;

                await dbContext.SaveChangesAsync();
            }
        }
        public async Task<GuildUsersPageServiceModel> GetUsersWithTheSameGameAsync(GuildUsersQueryModel queryModel, string gameName)
        {

            IQueryable<GuildRecruitUser> guildUsersQuery = this.dbContext
                .GuildRecruitUsers
                .Where(u => u.GameName == gameName)
                .AsQueryable();
            IQueryable<Banner> bannerQuery = this.dbContext
               .Banners
               .Where(b => b.GameName == gameName)
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


        public async Task<IEnumerable<ContactPlayerViewModel>> GetMyContactsByIdAsync(Guid userId)
        {

            return await dbContext.ContactPlayers
                .Where(cp => cp.UserId == userId)
                .Select(c => new ContactPlayerViewModel
                {
                    Id = c.Id,
                    NickName = c.NickName,
                    UrlLink = c.UrlLink,
                    Description = c.Description,
                    UserNickName = c.UserNickName,
                    UserId = c.Id,
                    GuildName = c.GuildName,
                    GameName = c.GameName,
                    ServerName = c.ServerName,
                    Feedback = c.Feedback,
                    IsAccepted = c.IsAccepted
                })
                .ToArrayAsync();
        }

        public async Task GetContactForAcceptByIdAsync(Guid id)
        {
            var contact = await dbContext.ContactPlayers.FindAsync(id);

            if (contact != null)
            {

                contact.IsAccepted = true;

                await dbContext.SaveChangesAsync();

            }
        }

        public async Task<GuildRecruitUserFormModel?> GetUserByUserNameForIdAsync(string userName)
        {

            return await dbContext.GuildRecruitUsers
                 .Where(x => x.UserName == userName)
                 .Select(b => new GuildRecruitUserFormModel
                 {
                     Id = b.Id
                 })
                 .FirstOrDefaultAsync();
        }

        public async Task SetUserAvatarAsync(GuildRecruitUserFormModel userModel, string pixId)
        {
            var user = await dbContext.GuildRecruitUsers.FindAsync(userModel.Id);

            if (user != null)
            {
                user.UserAvatarPix = pixId;

                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task RemoveGuildInfoAsync(GuildRecruitUserFormModel userModel)
        {  

            var userModelToDelete = await dbContext.GuildRecruitUsers
                                                               .Where(u => u.NickName == userModel.NickName)
                                                               .Select(u => new GuildRecruitUser
                                                               {
                                                                   Id = u.Id,
                                                                   NickName = u.NickName,
                                                                   UrlLink = u.UrlLink,
                                                                   GuildName = u.GuildName,
                                                                   ServerName = u.ServerName,
                                                                   GameName = u.GameName,
                                                                   Description = u.Description,
                                                                   UserName = u.UserName,
                                                                   UserAvatarPix = u.UserAvatarPix

                                                               })
                                                               .FirstOrDefaultAsync();

            var contactToBeDelete = await dbContext.ContactPlayers
                                                   .Where(c => c.UserId == userModelToDelete!.Id)
                                                   .ToArrayAsync();



            if (userModelToDelete != null)
            {

                foreach (var contact in contactToBeDelete)
                {
                    dbContext.ContactPlayers.Remove(contact);
                }

                dbContext.GuildRecruitUsers.Remove(userModelToDelete);
         
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task GetContactForRejectedByIdAsync(Guid id)
        {
            var contact = await dbContext.ContactPlayers.FindAsync(id);

            if (contact != null)
            {

                contact.IsAccepted = false;

                await dbContext.SaveChangesAsync();

            }
        }
    }
}
