
using GameGuildRecruit.Web.ViewModels.Banner;

namespace GameGuildRecruit.Web.ViewModels.GuildRecruitUser
{
    public class GuildUsersPageServiceModel
    {

        public GuildUsersPageServiceModel()
        {
            this.GuildUsers = new HashSet<GuildRecruitUserViewModel>();

            this.Banners = new HashSet<BannerViewModel>();
        }


        public int GuildUsersCount { get; set; }

        public IEnumerable<GuildRecruitUserViewModel> GuildUsers { get; set; }

        public int BannerCount { get; set; }

        public IEnumerable<BannerViewModel> Banners { get; set; }

    }
}
