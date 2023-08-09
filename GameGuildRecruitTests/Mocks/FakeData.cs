using GameGuildRecruit.Web.Data.Models;



namespace GameGuildRecruit.Tests.Mocks
{
    public static class FakeData
    {
        public static List<GuildRecruitUser> GuildRecruitUsers => new List<GuildRecruitUser>() 
        {
            new GuildRecruitUser()
            {
                Id = Guid.NewGuid(),
                NickName = "Avatar",
                UrlLink = "TestUrl",
                GuildName = "Test",
                ServerName = "DiabloTest",
                GameName = "Diablo",
                Description = "TestDescription",
                UserName = "TestName",
                UserAvatarPix = "MyPix"
            },

             new GuildRecruitUser()
            {
                Id = Guid.NewGuid(),
                NickName = "Avatar1",
                UrlLink = "TestUrl1",
                GuildName = "Test1",
                ServerName = "DiabloTest1",
                GameName = "Diablo1",
                Description = "TestDescription1",
                UserName = "TestName1",
                UserAvatarPix = "MyPix1"
            },

              new GuildRecruitUser()
            {
                Id = Guid.NewGuid(),
                NickName = "Avatar2",
                UrlLink = "TestUrl2",
                GuildName = "Test2",
                ServerName = "DiabloTest2",
                GameName = "Diablo2",
                Description = "TestDescription2",
                UserName = "TestName2",
                UserAvatarPix = "MyPix2"
            }

        };

        public static List<ContactPlayer> ContactPlayers => new List<ContactPlayer>() 
        {
            new ContactPlayer()
            {
                Id = Guid.NewGuid(),
                NickName = "TestName",
                Description = "TestDescription",
                UrlLink = "Test",
                GuildUserId = Guid.NewGuid(),
                UserNickName = "TestName",
                GuildName = "TestGuildName",
                ServerName = "TestServerName",
                GameName = "TestGameName",
                Feedback = "TestFeedback",
                IsAccepted = null
            },

             new ContactPlayer()
            {
                Id = Guid.NewGuid(),
                NickName = "TestName1",
                Description = "TestDescription1",
                UrlLink = "Test1",
                GuildUserId = Guid.NewGuid(),
                UserNickName = "TestName1",
                GuildName = "TestGuildName1",
                ServerName = "TestServerName1",
                GameName = "TestGameName1",
                Feedback = "TestFeedback1",
                IsAccepted = null
            },

              new ContactPlayer()
            {
                Id = Guid.NewGuid(),
                NickName = "TestName2",
                Description = "TestDescription2",
                UrlLink = "Test2",
                GuildUserId = Guid.NewGuid(),
                UserNickName = "TestName2",
                GuildName = "TestGuildName2",
                ServerName = "TestServerName2",
                GameName = "TestGameName2",
                Feedback = "TestFeedback2",
                IsAccepted = null
            }

        };

        public static List<Game> Games => new List<Game>()
        {
            new Game()
            {
                Id = Guid.NewGuid(),
                GameName = "WoW",
                GameSlideImageURL = "Test",
                GameLogoImageURL = "Test",
                IsGameHasView = false
            },

              new Game()
            {
                Id = Guid.NewGuid(),
                GameName = "WoW1",
                GameSlideImageURL = "Test1",
                GameLogoImageURL = "Test1",
                IsGameHasView = false
            },

                new Game()
            {
                Id = Guid.NewGuid(),
                GameName = "WoW2",
                GameSlideImageURL = "Test2",
                GameLogoImageURL = "Test2",
                IsGameHasView = false
            }
        };

        public static List<Banner> Banners => new List<Banner>()
        {
            new Banner()
            {
                Id = Guid.NewGuid(),
                GameName = "TestGameName",
                BannerImageURL = "TestBannerImageURL",
                BannerTitle = "TestBannerTitle",
                Description = "TestDescription",
                BannerURL = "TestBannerURL"
            },

            new Banner()
            {
                Id = Guid.NewGuid(),
                GameName = "TestGameName1",
                BannerImageURL = "TestBannerImageURL1",
                BannerTitle = "TestBannerTitle1",
                Description = "TestDescription1",
                BannerURL = "TestBannerURL1"
            },

            new Banner()
            {
                Id = Guid.NewGuid(),
                GameName = "TestGameName2",
                BannerImageURL = "TestBannerImageURL2",
                BannerTitle = "TestBannerTitle2",
                Description = "TestDescription2",
                BannerURL = "TestBannerURL2"
            }
        };

        public static List<Avatar> Avatars => new List<Avatar>()
        {
            new Avatar()
            {
                Id = Guid.NewGuid(),
                Name = "TestName",
                AvatarPixURL = "TestAvatarPixURL"
            },

             new Avatar()
            {
                Id = Guid.NewGuid(),
                Name = "TestName1",
                AvatarPixURL = "TestAvatarPixURL1"
            },

              new Avatar()
            {
                Id = Guid.NewGuid(),
                Name = "TestName2",
                AvatarPixURL = "TestAvatarPixURL2"
            }
        };
    }
}
