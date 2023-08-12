using System.ComponentModel.DataAnnotations;
using static GameGuildRecruit.Web.Common.EntityValidations.Banner;

namespace GameGuildRecruit.Web.ViewModels.Banner
{
    public class BannerFormModel
    {
        public BannerFormModel()
        {
            this.Id = Guid.NewGuid();
        }


        [Key]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "GameName")]
        public string GameName { get; set; } = null!;

        [Required]
        [Display(Name = "BannerImageURL")]
        public string BannerImageURL { get; set; } = null!;

        [Required]
        [StringLength(BannerTitleMaxLength, MinimumLength = BannerTitleMinLength)]
        [Display(Name = "BannerTitle")]
        public string BannerTitle { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        [Display(Name = "Description")]
        public string Description { get; set; } = null!;

        [Required]
        [Display(Name = "BannerURL")]
        public string BannerURL { get; set; } = null!;
    }
}
