using GameGuildRecruit.Web.Data.Models;
using GameGuildRecruit.Web.ViewModels.Banner;
using GameGuildRecruit.Web.ViewModels.ContactPlayer;
using GameGuildRecruit.Web.ViewModels.Game;
using GameGuildRecruit.Web.ViewModels.GuildRecruitUser;

namespace GameGuildRecruit.Tests.Mocks
{
    public static class FakeData
    {
        public static List<GuildRecruitUser> GuildRecruitUsers => new List<GuildRecruitUser>() 
        {
            new GuildRecruitUser()
            {
                Id = new Guid("5D67F493-0FF1-420E-9284-4A1802C7D342"),
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
                Id = new Guid("4BFC818A-EBCD-459A-B1B9-756AC08F0EFA"),
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
                Id = new Guid("01C58ED3-63E5-41A5-BA3D-ACC4AFEC36FE"),
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

        public static List<GuildRecruitUserFormModel> GuildRecruitUserFormModel => new List<GuildRecruitUserFormModel>()
        {
            new GuildRecruitUserFormModel()
            {
                Id = new Guid("5D67F493-0FF1-420E-9284-4A1802C7D342"),
                NickName = "Avatar",
                UrlLink = "TestUrl",
                GuildName = "Test",
                ServerName = "DiabloTest",
                GameName = "Diablo",
                Description = "TestDescription",
                UserName = "TestName",
                UserAvatarPix = "MyPix"
            },

             new GuildRecruitUserFormModel()
            {
                Id = new Guid("4BFC818A-EBCD-459A-B1B9-756AC08F0EFA"),
                NickName = "Avatar1",
                UrlLink = "TestUrl1",
                GuildName = "Test1",
                ServerName = "DiabloTest1",
                GameName = "Diablo1",
                Description = "TestDescription1",
                UserName = "TestName1",
                UserAvatarPix = "MyPix1"
            },

              new GuildRecruitUserFormModel()
            {
                Id = new Guid("01C58ED3-63E5-41A5-BA3D-ACC4AFEC36FE"),
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

        public static List<GuildRecruitUserViewModel> GuildRecruitUserViewModel => new List<GuildRecruitUserViewModel>()
        {
            new GuildRecruitUserViewModel()
            {
                Id = new Guid("5D67F493-0FF1-420E-9284-4A1802C7D342"),
                NickName = "Avatar",
                UrlLink = "TestUrl",
                GuildName = "Test",
                ServerName = "DiabloTest",
                GameName = "Diablo",
                Description = "TestDescription",
                UserName = "TestName",
                UserAvatarPix = "MyPix"
            },

             new GuildRecruitUserViewModel()
            {
                Id = new Guid("4BFC818A-EBCD-459A-B1B9-756AC08F0EFA"),
                NickName = "Avatar1",
                UrlLink = "TestUrl1",
                GuildName = "Test1",
                ServerName = "DiabloTest1",
                GameName = "Diablo1",
                Description = "TestDescription1",
                UserName = "TestName1",
                UserAvatarPix = "MyPix1"
            },

              new GuildRecruitUserViewModel()
            {
                Id = new Guid("01C58ED3-63E5-41A5-BA3D-ACC4AFEC36FE"),
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
                Id = new Guid("01C58ED3-63E5-41A5-BA3D-ACC4AFEC36FE"),
                NickName = "TestName",
                Description = "TestDescription",
                UrlLink = "Test",
                GuildUserId = new Guid("5D67F493-07F1-420E-9284-4A1802C7D342"),
                UserNickName = "TestName",
                GuildName = "TestGuildName",
                ServerName = "TestServerName",
                GameName = "TestGameName",
                Feedback = "TestFeedback",
                IsAccepted = null
            },

             new ContactPlayer()
            {
                Id = new Guid("4BFC818A-EBCD-459A-B1B9-756AC08F0EFA"),
                NickName = "TestName1",
                Description = "TestDescription1",
                UrlLink = "Test1",
                GuildUserId = new Guid("5767F493-0FF1-420E-9284-4A1802C7D342"),
                UserNickName = "TestName1",
                GuildName = "TestGuildName1",
                ServerName = "TestServerName1",
                GameName = "TestGameName1",
                Feedback = "TestFeedback1",
                IsAccepted = null
            },

              new ContactPlayer()
            {
                Id = new Guid("5D67F493-0FF1-420E-9284-4A1802C7D342"),
                NickName = "TestName2",
                Description = "TestDescription2",
                UrlLink = "Test2",
                GuildUserId = new Guid("1D67F493-0FF1-420E-9284-4A1802C7D342"),
                UserNickName = "TestName2",
                GuildName = "TestGuildName2",
                ServerName = "TestServerName2",
                GameName = "TestGameName2",
                Feedback = "TestFeedback2",
                IsAccepted = null
            }

        };

        public static List<ContactPlayerViewModel> ContactPlayerViewModel => new List<ContactPlayerViewModel>()
        {
            new ContactPlayerViewModel()
            {
                Id = new Guid("01C58ED3-63E5-41A5-BA3D-ACC4AFEC36FE"),
                NickName = "TestName",
                Description = "TestDescription",
                UrlLink = "Test",
                GuildUserId = new Guid("5D67F493-07F1-420E-9284-4A1802C7D342"),
                UserNickName = "TestName",
                GuildName = "TestGuildName",
                ServerName = "TestServerName",
                GameName = "TestGameName",
                Feedback = "TestFeedback",
                IsAccepted = null
            },

             new ContactPlayerViewModel()
            {
                Id = new Guid("4BFC818A-EBCD-459A-B1B9-756AC08F0EFA"),
                NickName = "TestName1",
                Description = "TestDescription1",
                UrlLink = "Test1",
                GuildUserId = new Guid("5767F493-0FF1-420E-9284-4A1802C7D342"),
                UserNickName = "TestName1",
                GuildName = "TestGuildName1",
                ServerName = "TestServerName1",
                GameName = "TestGameName1",
                Feedback = "TestFeedback1",
                IsAccepted = null
            },

              new ContactPlayerViewModel()
            {
                Id = new Guid("5D67F493-0FF1-420E-9284-4A1802C7D342"),
                NickName = "TestName2",
                Description = "TestDescription2",
                UrlLink = "Test2",
                GuildUserId = new Guid("1D67F493-0FF1-420E-9284-4A1802C7D342"),
                UserNickName = "TestName2",
                GuildName = "TestGuildName2",
                ServerName = "TestServerName2",
                GameName = "TestGameName2",
                Feedback = "TestFeedback2",
                IsAccepted = null
            }

        };

        public static List<ContactPlayerFormModel> ContactPlayerFormModel => new List<ContactPlayerFormModel>()
        {
            new ContactPlayerFormModel()
            {
                Id = new Guid("01C58ED3-63E5-41A5-BA3D-ACC4AFEC36FE"),
                NickName = "TestName",
                Description = "TestDescription",
                UrlLink = "Test"

            },

             new ContactPlayerFormModel()
            {
                Id = new Guid("4BFC818A-EBCD-459A-B1B9-756AC08F0EFA"),
                NickName = "TestName1",
                Description = "TestDescription1",
                UrlLink = "Test1"

            },

              new ContactPlayerFormModel()
            {
                Id = new Guid("5D67F493-0FF1-420E-9284-4A1802C7D342"),
                NickName = "TestName2",
                Description = "TestDescription2",
                UrlLink = "Test2",
                Feedback = "TestFeedback2"

            }

        };

        public static List<Game> Games => new List<Game>()
        {
            new Game()
            {
                Id = new Guid("5D67F493-0FF1-420E-9284-4A1802C7D342"),
                GameName = "WoW",
                GameSlideImageURL = "Test",
                GameLogoImageURL = "Test",
                IsGameHasView = false
            },

              new Game()
            {
                Id = new Guid("4BFC818A-EBCD-459A-B1B9-756AC08F0EFA"),
                GameName = "WoW1",
                GameSlideImageURL = "Test1",
                GameLogoImageURL = "Test1",
                IsGameHasView = false
            },

                new Game()
            {
                Id = new Guid("01C58ED3-63E5-41A5-BA3D-ACC4AFEC36FE"),
                GameName = "WoW2",
                GameSlideImageURL = "Test2",
                GameLogoImageURL = "Test2",
                IsGameHasView = false
            }
        };

        public static List<GameFormModel> GameFormModel => new List<GameFormModel>()
        {
            new GameFormModel()
            {
                Id = new Guid("5D67F493-0FF1-420E-9284-4A1802C7D342"),
                GameName = "WoW",
                GameSlideImageURL = "Test",
                GameLogoImageURL = "Test",
                IsGameHasView = false
            },

              new GameFormModel()
            {
                Id = new Guid("4BFC818A-EBCD-459A-B1B9-756AC08F0EFA"),
                GameName = "WoW1",
                GameSlideImageURL = "Test1",
                GameLogoImageURL = "Test1",
                IsGameHasView = false
            },

                new GameFormModel()
            {
                Id = new Guid("01C58ED3-63E5-41A5-BA3D-ACC4AFEC36FE"),
                GameName = "WoW2",
                GameSlideImageURL = "Test2",
                GameLogoImageURL = "Test2",
                IsGameHasView = false
            }
        };

        public static List<GameViewModel> GameViewModel => new List<GameViewModel>()
        {
            new GameViewModel()
            {
                Id = new Guid("5D67F493-0FF1-420E-9284-4A1802C7D342"),
                GameName = "WoW",
                GameSlideImageURL = "Test",
                GameLogoImageURL = "Test",
                IsGameHasView = false
            },

              new GameViewModel()
            {
                Id = new Guid("4BFC818A-EBCD-459A-B1B9-756AC08F0EFA"),
                GameName = "WoW1",
                GameSlideImageURL = "Test1",
                GameLogoImageURL = "Test1",
                IsGameHasView = false
            },

                new GameViewModel()
            {
                Id = new Guid("01C58ED3-63E5-41A5-BA3D-ACC4AFEC36FE"),
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
                Id = new Guid("5D67F493-0FF1-420E-9284-4A1802C7D342"),
                GameName = "TestGameName",
                BannerImageURL = "TestBannerImageURL",
                BannerTitle = "TestBannerTitle",
                Description = "TestDescription",
                BannerURL = "TestBannerURL"
            },

            new Banner()
            {
                Id = new Guid("01C58ED3-63E5-41A5-BA3D-ACC4AFEC36FE"),
                GameName = "TestGameName1",
                BannerImageURL = "TestBannerImageURL1",
                BannerTitle = "TestBannerTitle1",
                Description = "TestDescription1",
                BannerURL = "TestBannerURL1"
            },

            new Banner()
            {
                Id = new Guid("01C588D3-63E5-41A5-BA3D-ACC4AFEC36FE"),
                GameName = "TestGameName2",
                BannerImageURL = "TestBannerImageURL2",
                BannerTitle = "TestBannerTitle2",
                Description = "TestDescription2",
                BannerURL = "TestBannerURL2"
            }
        };

        public static List<BannerFormModel> BannerFormModels => new List<BannerFormModel>()
        {
            new BannerFormModel()
            {
                Id = new Guid("5D67F493-0FF1-420E-9284-4A1802C7D342"),
                GameName = "TestGameName",
                BannerImageURL = "TestBannerImageURL",
                BannerTitle = "TestBannerTitle",
                Description = "TestDescription",
                BannerURL = "TestBannerURL"
            },

            new BannerFormModel()
            {
                Id = new Guid("01C58ED3-63E5-41A5-BA3D-ACC4AFEC36FE"),
                GameName = "TestGameName1",
                BannerImageURL = "TestBannerImageURL1",
                BannerTitle = "TestBannerTitle1",
                Description = "TestDescription1",
                BannerURL = "TestBannerURL1"
            },

            new BannerFormModel()
            {
                Id = new Guid("01C588D3-63E5-41A5-BA3D-ACC4AFEC36FE"),
                GameName = "TestGameName2",
                BannerImageURL = "TestBannerImageURL2",
                BannerTitle = "TestBannerTitle2",
                Description = "TestDescription2",
                BannerURL = "TestBannerURL2"
            }
        };

        public static List<BannerViewModel> BannerViewModel => new List<BannerViewModel>()
        {
            new BannerViewModel()
            {
                Id = new Guid("5D67F493-0FF1-420E-9284-4A1802C7D342"),
                GameName = "TestGameName",
                BannerImageURL = "TestBannerImageURL",
                BannerTitle = "TestBannerTitle",
                Description = "TestDescription",
                BannerURL = "TestBannerURL"
            },

            new BannerViewModel()
            {
                Id = new Guid("01C58ED3-63E5-41A5-BA3D-ACC4AFEC36FE"),
                GameName = "TestGameName1",
                BannerImageURL = "TestBannerImageURL1",
                BannerTitle = "TestBannerTitle1",
                Description = "TestDescription1",
                BannerURL = "TestBannerURL1"
            },

            new BannerViewModel()
            {
                Id = new Guid("01C588D3-63E5-41A5-BA3D-ACC4AFEC36FE"),
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
                Id = new Guid("01C588D3-63E5-41A5-BA3D-ACC4AFEC36FE"),
                Name = "TestName",
                AvatarPixURL = "TestAvatarPixURL"
            },

             new Avatar()
            {
                Id = new Guid("01C58ED3-63E5-41A5-BA3D-ACC4AFEC36FE"),
                Name = "TestName1",
                AvatarPixURL = "TestAvatarPixURL1"
            },

              new Avatar()
            {
                Id = new Guid("5D67F493-0FF1-420E-9284-4A1802C7D342"),
                Name = "TestName2",
                AvatarPixURL = "TestAvatarPixURL2"
            }
        };
    }
}
