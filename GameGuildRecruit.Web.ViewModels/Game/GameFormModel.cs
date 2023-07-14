
using System.ComponentModel.DataAnnotations;
using static GameGuildRecruit.Web.Common.EntityValidations.Game;

namespace GameGuildRecruit.Web.ViewModels.Game
{
    public class GameFormModel
    {
        public GameFormModel()
        {
            this.Id = Guid.NewGuid();
        }


        [Key]
        public Guid Id { get; set; }


        [Required]
        [StringLength(GameNameMaxLength, MinimumLength = GameNameMinLength)]
        [Display(Name = "GameName")]
        public string GameName { get; set; } = null!;

        [Required]
        [Display(Name = "GameSlideImageURL")]
        public string GameSlideImageURL { get; set; } = null!;

        [Required]
        [Display(Name = "GameLogoImageURL")]
        public string GameLogoImageURL { get; set; } = null!;

        public bool IsGameHasView { get; set; } = false;

    }
}
