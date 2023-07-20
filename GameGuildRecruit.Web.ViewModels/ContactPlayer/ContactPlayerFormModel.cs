using System.ComponentModel.DataAnnotations;
using static GameGuildRecruit.Web.Common.EntityValidations.ContactPlayer;

namespace GameGuildRecruit.Web.ViewModels.ContactPlayer
{
    public class ContactPlayerFormModel
    {
        public ContactPlayerFormModel()
        {
            this.Id = Guid.NewGuid();
            this.GuildUserId = Guid.NewGuid();

        }


        public Guid Id { get; set; }


        [Required]
        [StringLength(NicknameMaxLength, MinimumLength = NicknameMinLength)]
        [Display(Name = "NickName")]
        public string NickName { get; set; } = null!;

        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Display(Name = "UrlLink")]
        public string? UrlLink { get; set; }

        [Display(Name = "GuildUserId")]
        public Guid? GuildUserId { get; set; }

        [Display(Name = "UserNickName")]
        public string? UserNickName { get; set; }

        [Display(Name = "GuildName")]
        public string? GuildName { get; set; }

        [Display(Name = "ServerName")]
        public string? ServerName { get; set; }

        [Display(Name = "GameName")]
        public string? GameName { get; set; }

        [Display(Name = "Feedback")]
        public string? Feedback { get; set; }

        public bool? IsAccepted { get; set; }


    }
}
