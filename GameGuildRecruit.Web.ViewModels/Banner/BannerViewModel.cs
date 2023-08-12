using System.ComponentModel.DataAnnotations;

namespace GameGuildRecruit.Web.ViewModels.Banner
{
    public class BannerViewModel
    {
        public BannerViewModel()
        {
            this.Id = Guid.NewGuid();
        }


        [Key]
        public Guid Id { get; set; }

        public string GameName { get; set; } = null!;

        public string BannerImageURL { get; set; } = null!;

        public string BannerTitle { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string BannerURL { get; set; } = null!;
    }
}
