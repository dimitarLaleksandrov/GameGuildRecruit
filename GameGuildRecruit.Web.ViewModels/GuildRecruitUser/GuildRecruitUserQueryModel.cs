

namespace GameGuildRecruit.Web.ViewModels.GuildRecruitUser
{
    public class GuildRecruitUserQueryModel
    {
        public GuildRecruitUserQueryModel()
        {
            this.GuildRecruitUsers = new HashSet<GuildRecruitUserFormModel>();
        }

        public int GuildUsersCount { get; set; }


        public IEnumerable<GuildRecruitUserFormModel> GuildRecruitUsers { get; set; }
    }
}
