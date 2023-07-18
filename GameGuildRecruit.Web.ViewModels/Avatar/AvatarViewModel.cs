
using System.ComponentModel.DataAnnotations;

namespace GameGuildRecruit.Web.ViewModels.Avatar
{
    public class AvatarViewModel
    {
        public AvatarViewModel()
        {
            this.Id = Guid.NewGuid();
        }


        [Key]
        public Guid Id { get; set; }
   
        public string Name { get; set; } = null!;
  
        public string AvatarPixURL { get; set; } = null!;
    }
}
