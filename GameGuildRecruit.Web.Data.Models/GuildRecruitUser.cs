using System.ComponentModel.DataAnnotations;
using static GameGuildRecruit.Web.Common.EntityValidations.GuildRecruitUser;


namespace GameGuildRecruit.Web.Data.Models
{
    public class GuildRecruitUser
    {
        public GuildRecruitUser()
        {
            this.Id = Guid.NewGuid();

            this.Contacts = new HashSet<IdentityUserContact>();
        }


        [Key]
        public Guid Id { get; set; }


        [Required]
        [MaxLength(NicknameMaxLength)]
        public string NickName { get; set; } = null!;


        [Required]
        [MaxLength(GuildNameMaxLength)]
        public string GuildName { get; set; } = null!;


        [Required]
        [MaxLength(GameNameMaxLength)]
        public string GameName { get; set; } = null!;


        [MaxLength(ServerNameMaxLength)]
        public string? ServerName { get; set; }

        public string? UrlLink { get; set; }


        [MaxLength(DescriptionMaxLength)]
        public string? Description { get; set; }

        public string? UserName { get; set; }


        public string? UserAvatarPix { get; set; }


        public virtual ICollection<IdentityUserContact> Contacts { get; set; }

    }
}
