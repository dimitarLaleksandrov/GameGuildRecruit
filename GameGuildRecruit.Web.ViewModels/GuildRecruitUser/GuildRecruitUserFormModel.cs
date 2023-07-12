using GameGuildRecruit.Web.Common.Enums;
using GameGuildRecruit.Web.ViewModels.ContactPlayer;
using System.ComponentModel.DataAnnotations;
using static GameGuildRecruit.Web.Common.EntityValidations.GuildRecruitUser;



namespace GameGuildRecruit.Web.ViewModels.GuildRecruitUser
{
    public class GuildRecruitUserFormModel
    {
        public GuildRecruitUserFormModel()
        {
            this.Contacts = new HashSet<ContactPlayerViewModel>();

            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }


        [Required]
        [StringLength(NicknameMaxLength, MinimumLength = NicknameMinLength)]
        [Display(Name = "NickName")]
        public string NickName { get; set; } = null!;

        [Required]
        [StringLength(GuildNameMaxLength, MinimumLength = GuildNameMinLength)]
        [Display(Name = "GuildName")]
        public string GuildName { get; set; } = null!;

        [Required]
        [StringLength(GameNameMaxLength)]
        [Display(Name = "GameName")]
        public string GameName { get; set; } = null!;

        [StringLength(ServerNameMaxLength, MinimumLength = ServerNameMinLength)]
        [Display(Name = "ServerName")]
        public string? ServerName { get; set; }

        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Display(Name = "UrlLink")]
        public string? UrlLink { get; set; }

        public string? UserName { get; set; }

        [Display(Name = "UserAvatarPix")]
        public string? UserAvatarPix { get; set; }

        [Display(Name = "UserContactNum")]

        public int? UserContactNum { get; set; }



        public ICollection<ContactPlayerViewModel> Contacts { get; set; }

    }
}
