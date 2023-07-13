
using System.ComponentModel.DataAnnotations;
using static GameGuildRecruit.Web.Common.EntityValidations.Banner;

namespace GameGuildRecruit.Web.Data.Models
{
    public class Banner
    {
        public Banner()
        {
            this.Id = Guid.NewGuid();
        }


        [Key]
        public Guid Id { get; set; }

        [Required]
        public string GameName { get; set; } = null!;

        [Required]
        public string BannerImageURL { get; set; } = null!;

        [Required]
        [MaxLength(BannerTitleMaxLength)]
        public string BannerTitle { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string BannerURL { get; set; } = null!;
    }
}
