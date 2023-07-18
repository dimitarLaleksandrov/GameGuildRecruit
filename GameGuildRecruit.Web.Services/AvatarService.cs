using GameGuildRecruit.Web.Data;
using GameGuildRecruit.Web.Services.Interfaces;
using GameGuildRecruit.Web.ViewModels.GuildRecruitUser;

namespace GameGuildRecruit.Web.Services



{
    public class AvatarService : IAvatarService
    {

        private readonly GameGuildRecruitDbContext dbContext;

        public AvatarService(GameGuildRecruitDbContext dbContext)
        {
            this.dbContext = dbContext;
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
