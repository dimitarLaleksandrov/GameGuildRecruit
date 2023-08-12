namespace GameGuildRecruit.Web.ViewModels.ContactPlayer

{
    public class ContactPlayerViewModel
    {
        public ContactPlayerViewModel()
        {
            this.Id = Guid.NewGuid();
            this.GuildUserId = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string NickName { get; set; } = null!;

        public string? Description { get; set; }

        public string? UrlLink { get; set; }

        public Guid GuildUserId { get; set; }

        public string? UserNickName { get; set; }

        public string? GuildName { get; set; }

        public string? ServerName { get; set; }

        public string? GameName { get; set; }

        public string? Feedback { get; set; }

        public bool? IsAccepted { get; set; }
    }
}
