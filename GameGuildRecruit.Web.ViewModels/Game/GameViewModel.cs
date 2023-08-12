using System.ComponentModel.DataAnnotations;

namespace GameGuildRecruit.Web.ViewModels.Game
{
    public class GameViewModel
    {

        public GameViewModel()
        {
            this.Id = Guid.NewGuid();
        }


        [Key]
        public Guid Id { get; set; }

        public string GameName { get; set; } = null!;

        public string GameSlideImageURL { get; set; } = null!;

        public string GameLogoImageURL { get; set; } = null!;

        public bool IsGameHasView { get; set; } = false;
    }
}
