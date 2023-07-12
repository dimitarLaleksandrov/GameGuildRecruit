

using GameGuildRecruit.Web.Common.Enums;

namespace GameGuildRecruit.Web.ViewModels.GuildRecruitUser
{
    public class GuildRecruitUserViewModel
    {
        public GuildRecruitUserViewModel()
        {
            this.Id = Guid.NewGuid();
        }


        public Guid Id { get; set; }


        public string NickName { get; set; } = null!;

        public string GuildName { get; set; } = null!;

        public GameNames GameName { get; set; }

        public string? UrlLink { get; set; }

        public string? ServerName { get; set; }

        public string? UserName { get; set; }

        public string? Description { get; set; }

        public string? UserAvatarPix { get; set; }

        public int? UserContactNum { get; set; }


    }
}
