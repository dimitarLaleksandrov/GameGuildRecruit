using System.ComponentModel.DataAnnotations.Schema;

namespace GameGuildRecruit.Web.Data.Models
{
    public class IdentityUserContact
    {
        public IdentityUserContact()
        {

            this.ContactId = Guid.NewGuid();
            this.GuildUserId = Guid.NewGuid();

        }


        public Guid GuildUserId { get; set; }


        [ForeignKey(nameof(GuildUserId))]
        public GuildRecruitUser GuildUser { get; set; } = null!;


        public Guid ContactId { get; set; }


        [ForeignKey(nameof(ContactId))]
        public ContactPlayer Contact { get; set; } = null!;
    }
}
