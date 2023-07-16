


namespace GameGuildRecruit.Web.ViewModels.Game
{
    public class GamesPageServiceModel
    {
        public GamesPageServiceModel()
        {
            this.Games = new HashSet<GameFormModel>();
        }

        public int GamesCount { get; set; }


        public IEnumerable<GameFormModel> Games { get; set; }
    }
}
