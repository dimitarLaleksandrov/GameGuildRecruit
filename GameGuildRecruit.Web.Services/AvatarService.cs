using GameGuildRecruit.Web.Data;
using GameGuildRecruit.Web.Services.Interfaces;
using GameGuildRecruit.Web.ViewModels.Avatar;
using GameGuildRecruit.Web.ViewModels.GuildRecruitUser;
using GameGuildRecruit.Web.Data.Models;

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


        public async Task SetUserAvatarAsync(GuildRecruitUserFormModel userModel, string pixId)
        {
            var user = await dbContext.GuildRecruitUsers.FindAsync(userModel.Id);

            if (user != null)
            {
                user.UserAvatarPix = pixId;

                await this.dbContext.SaveChangesAsync();
            }
        }

    }
}
