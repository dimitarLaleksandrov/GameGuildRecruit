using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameGuildRecruit.Tests.Mocks;
using GameGuildRecruit.Web.Data;
using GameGuildRecruit.Web.Data.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace GameGuildRecruit.Tests.UnitTests
{
    public class UnitTestsBase
    {

        protected GameGuildRecruitDbContext _data;

        [OneTimeSetUp]
        public void SeedUpBase()
        {
            _data = DatabaseMock.Instance;

            SeedDatabase();
        }

      
        public Game Game { get; private set; }

        public ContactPlayer Contact { get; private set; }

        public Banner Banner { get; private set; }

        public Avatar Avatar { get; private set; }


        private void SeedDatabase() 
        {
            GuildRecruitUser = FakeData.GuildRecruitUsers[0];
          
            _data.GuildRecruitUsers.Add(GuildRecruitUser);

            Game = new Game()
            {
                Id = Guid.NewGuid(),
                GameName = "WoW",
                GameSlideImageURL = "Test",
                GameLogoImageURL = "Test",
                IsGameHasView = false
            };
            _data.Games.Add(Game);

            Contact = new ContactPlayer()
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
            };
            _data.ContactPlayers.Add(Contact);

            Banner = new Banner() 
            {
                Id = Guid.NewGuid(),
                GameName = "TestGameName",
                BannerImageURL = "TestBannerImageURL",
                BannerTitle = "TestBannerTitle",
                Description = "TestDescription",
                BannerURL = "TestBannerURL"
            };
            _data.Banners.Add(Banner);

            Avatar = new Avatar() 
            {
                Id = Guid.NewGuid(),
                Name = "TestName",
                AvatarPixURL = "TestAvatarPixURL"
            };
            _data.Avatars.Add(Avatar);

            _data.SaveChanges();

        }

    }
}
