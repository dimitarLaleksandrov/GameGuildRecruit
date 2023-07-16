

using GameGuildRecruit.Web.ViewModels.GuildRecruitUser;

namespace GameGuildRecruit.Web.ViewModels.Game
{
    public class GameQueryModel
    {
        public GameQueryModel()
        {
            this.Games = new HashSet<GameFormModel>();
        }

        public int GamesCount { get; set; }


        public IEnumerable<GameFormModel> Games { get; set; }
    }
}
