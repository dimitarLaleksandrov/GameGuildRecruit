﻿
using GameGuildRecruit.Web.ViewModels.Banner;

namespace GameGuildRecruit.Web.ViewModels.GuildRecruitUser
{
    public class GuildUsersPageServiceModel
    {

        public GuildUsersPageServiceModel()
        {
            this.GuildUsers = new HashSet<GuildRecruitUserFormModel>();

            this.Banners = new HashSet<BannerFormModel>();
        }


        public int GuildUsersCount { get; set; }

        public IEnumerable<GuildRecruitUserFormModel> GuildUsers { get; set; }

        public int BannerCount { get; set; }

        public IEnumerable<BannerFormModel> Banners { get; set; }

    }
}
