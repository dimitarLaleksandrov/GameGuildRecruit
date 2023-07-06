
namespace GameGuildRecruit.Web.ViewModels.GuildRecruitUser
{
    public class GuildUsersPageServiceModel
    {

        public GuildUsersPageServiceModel()
        {
            this.GuildUsers = new HashSet<GuildRecruitUserFormModel>();
        }


        public int GuildUsersCount { get; set; }

        public IEnumerable<GuildRecruitUserFormModel> GuildUsers { get; set; }
    }
}
