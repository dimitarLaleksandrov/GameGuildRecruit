using System.ComponentModel.DataAnnotations;
using static GameGuildRecruit.Web.Common.PageConstants;

namespace GameGuildRecruit.Web.ViewModels.GuildRecruitUser
{
    public class GuildUsersQueryModel
    {
        public GuildUsersQueryModel()
        {
            this.CurrentPage = DefaultPage;
            this.UserPerPage = EntitiesPerPage;

            this.GuildUsers = new HashSet<GuildRecruitUserFormModel>();
        }

        public string? GuildName { get; set; }

        public string? SearchString { get; set; }

        public int CurrentPage { get; set; }

        [Display(Name = "Show Users On Page")]
        public int UserPerPage { get; set; }

        public int GuildUsersCount { get; set; }

        public IEnumerable<GuildRecruitUserFormModel> GuildUsers { get; set; }
    }
}
