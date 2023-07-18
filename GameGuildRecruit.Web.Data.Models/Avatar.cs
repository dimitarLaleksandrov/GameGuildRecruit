
using System.ComponentModel.DataAnnotations;
using static GameGuildRecruit.Web.Common.EntityValidations.Avatar;


namespace GameGuildRecruit.Web.Data.Models
{
    public class Avatar
    {
        public Avatar()
        {
            this.Id = Guid.NewGuid();
        }


        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(AvatarTitleMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public string AvatarPixURL { get; set; } = null!;
    }
}
