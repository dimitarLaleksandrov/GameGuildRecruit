using System.ComponentModel.DataAnnotations;
using static GameGuildRecruit.Web.Common.EntityValidations.ContactPlayer;


namespace GameGuildRecruit.Web.Data.Models
{
    public class ContactPlayer
    {
        public ContactPlayer()
        {
            this.Id = Guid.NewGuid();
            this.UserId = Guid.NewGuid();

        }


        [Key]
        public Guid Id { get; set; }


        [Required]
        [MaxLength(NicknameMaxLength)]
        public string NickName { get; set; } = null!;


        [MaxLength(DescriptionMaxLength)]
        public string? Description { get; set; }

        public string? Feedback { get; set; }

        public string? UrlLink { get; set; }

        public Guid UserId { get; set; }

        public string? UserNickName { get; set; }

        public string? GuildName { get; set; }

        public string? ServerName { get; set; }

        public string? GameName { get; set; }

        public bool? IsAccepted { get; set; }


    }
}
