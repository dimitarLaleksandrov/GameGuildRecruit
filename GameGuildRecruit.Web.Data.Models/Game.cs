
using System.ComponentModel.DataAnnotations;
using static GameGuildRecruit.Web.Common.EntityValidations.Game;

namespace GameGuildRecruit.Web.Data.Models
{
    public class Game
    {
        public Game()
        {
            this.Id = Guid.NewGuid();
        }


        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(GameNameMaxLength)]
        public string GameName { get; set; } = null!;

        [Required]
        public string GameSlideImageURL { get; set; } = null!;

        [Required]
        public string GameLogoImageURL { get; set; } = null!;

        public bool IsGameHasView { get; set; } = false;

    }
}
