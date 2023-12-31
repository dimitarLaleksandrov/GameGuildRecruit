﻿using GameGuildRecruit.Web.ViewModels.Banner;
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

            this.GuildUsers = new HashSet<GuildRecruitUserViewModel>();
            this.Banners = new HashSet<BannerViewModel>();

        }

        public string? GuildName { get; set; }

        public string? SearchString { get; set; }

        public int CurrentPage { get; set; }

        [Display(Name = "Show Users On Page")]
        public int UserPerPage { get; set; }

        public int GuildUsersCount { get; set; }

        public IEnumerable<GuildRecruitUserViewModel> GuildUsers { get; set; }

        public int BannerCount { get; set; }

        public IEnumerable<BannerViewModel> Banners { get; set; }
    }
}
