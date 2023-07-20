using GameGuildRecruit.Web.Data;
using GameGuildRecruit.Web.Services.Interfaces;
using GameGuildRecruit.Web.ViewModels.Avatar;
using GameGuildRecruit.Web.ViewModels.GuildRecruitUser;
using GameGuildRecruit.Web.Data.Models;
using Microsoft.EntityFrameworkCore;
using GameGuildRecruit.Web.ViewModels.Banner;

namespace GameGuildRecruit.Web.Services



{
    public class AvatarService : IAvatarService
    {

        private readonly GameGuildRecruitDbContext dbContext;

        public AvatarService(GameGuildRecruitDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        public async Task<AvatarFormModel> GetNewAvatarModelAsync()
        {

            var avatarModel =  new AvatarFormModel
            {

            };

            return avatarModel;
        }

        public async Task AddAvatarAsync(AvatarFormModel avatarModel, Guid id)
        {
            var avatar =  new Avatar()
            {
                Id = id,
                Name = avatarModel.Name,
                AvatarPixURL = avatarModel.AvatarPixURL
              
            };

            await dbContext.Avatars.AddAsync(avatar);
            await this.dbContext.SaveChangesAsync();
        }


        public async Task<AvatarFormModel?> GetAvatarByIdAsync(Guid id)
        {
            return await dbContext.Avatars
                .Where(x => x.Id == id)
                .Select(a => new AvatarFormModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    AvatarPixURL = a.AvatarPixURL

                })
                .FirstOrDefaultAsync();
        }

        public async Task SetUserAvatarAsync(GuildRecruitUserFormModel userModel, string avatarPixURL)
        {
            var user = await dbContext.GuildRecruitUsers.FindAsync(userModel.Id);

            if (user != null)
            {
                user.UserAvatarPix = avatarPixURL;

                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task EditAvatarAsync(AvatarFormModel avatarModel)
        {
            var findAvatarById = await dbContext.Avatars.Where(x => x.Id == avatarModel.Id).FirstOrDefaultAsync();

            if (findAvatarById != null)
            {
                findAvatarById.Id = avatarModel.Id;
                findAvatarById.Name = avatarModel.Name;
                findAvatarById.AvatarPixURL = avatarModel.AvatarPixURL;

                await dbContext.SaveChangesAsync();
            }
        }

        public async Task RemoveAvatarAsync(Guid id)
        {
            var avatarModelToDelete = await dbContext.Avatars
                                        .Where(a => a.Id == id)
                                          .Select(u => new Avatar
                                          {
                                              Id = u.Id,
                                              Name = u.Name,
                                              AvatarPixURL = u.AvatarPixURL
                                          })
                                          .FirstOrDefaultAsync();

            if (avatarModelToDelete != null)
            {
                dbContext.Avatars.Remove(avatarModelToDelete);

                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<AvatarViewModel>> GetAvatarsAsync()
        {
            return await dbContext.Avatars
              .Select(a => new AvatarViewModel
              {
                  Id = a.Id,
                  Name = a.Name,
                  AvatarPixURL = a.AvatarPixURL

              })
              .OrderBy(x => x.Name)
              .ThenBy(x => x.AvatarPixURL)
              .ToArrayAsync();
        }
    }
}
