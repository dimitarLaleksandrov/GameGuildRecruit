

using GameGuildRecruit.Web.ViewModels.GuildRecruitUser;
using System.ComponentModel.DataAnnotations;
using static GameGuildRecruit.Web.Common.PageConstants;

namespace GameGuildRecruit.Web.ViewModels.Game
{
    public class GamesQueryModel
    {
        public GamesQueryModel()
        {
            this.CurrentPage = DefaultPage;
            this.UserPerPage = EntitiesPerPage;

            this.Games = new HashSet<GameFormModel>();
        }

        public string? GuildName { get; set; }

        public string? SearchString { get; set; }

        public int CurrentPage { get; set; }

        [Display(Name = "Show Users On Page")]
        public int UserPerPage { get; set; }

        public int GamesCount { get; set; }

        public IEnumerable<GameFormModel> Games { get; set; }
    }
}
