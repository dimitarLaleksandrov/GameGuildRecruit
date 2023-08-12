using System.ComponentModel.DataAnnotations;
using static GameGuildRecruit.Web.Common.EntityValidations.Avatar;


namespace GameGuildRecruit.Web.ViewModels.Avatar
{
    public class AvatarFormModel
    {
        public AvatarFormModel()
        {
            this.Id = Guid.NewGuid();
        }


        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(AvatarNameMaxLength, MinimumLength = AvatarNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        public string AvatarPixURL { get; set; } = null!;
    }
}
