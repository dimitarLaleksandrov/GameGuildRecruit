using GameGuildRecruit.Web.Data;
using GameGuildRecruit.Web.Services.Interfaces;
using GameGuildRecruit.Web.Services;
using Microsoft.EntityFrameworkCore;
using static GameGuildRecruit.Tests.UnitTests.DataBaseSeeder;
using GameGuildRecruit.Web.ViewModels.Game;
using GameGuildRecruit.Web.ViewModels.Banner;
using GameGuildRecruit.Tests.Mocks;

namespace GameGuildRecruit.Tests.UnitTests
{
    [TestFixture]
    public class BannerServiceTests
    {

        private DbContextOptions<GameGuildRecruitDbContext> dbOptions;
        private GameGuildRecruitDbContext dbContext;

        private IBannerService bannerService;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            dbOptions = new DbContextOptionsBuilder<GameGuildRecruitDbContext>()
               .UseInMemoryDatabase("GameGuildRecruitInMemoryDb" + Guid.NewGuid().ToString())
               .Options;

            dbContext = new GameGuildRecruitDbContext(dbOptions);

            dbContext.Database.EnsureCreated();

            SeedDataBase(dbContext);

            bannerService = new BannerService(dbContext);

        }

        [Test]
        public async Task AddBannerAsyncShouldAddBannerInDb()
        {
            var bannerId = new Guid("01C548D3-63E5-41A5-BA3D-ACC4AFEC36FE");

            var newBanner = new BannerFormModel()
            {
                GameName = "TestGameName2",
                BannerImageURL = "TestBannerImageURL2",
                BannerTitle = "TestBannerTitle2",
                Description = "TestDescription2",
                BannerURL = "TestBannerURL2"
            };

            await bannerService.AddBannerAsync(newBanner, bannerId);

            Assert.That(dbContext.Banners.Count() == 4);

        }

        [Test]
        public async Task GetBannerByIdAsyncShouldReturnBanner()
        {
            var bannerId = new Guid("01C588D3-63E5-41A5-BA3D-ACC4AFEC36FE");

            var result = await bannerService.GetBannerByIdAsync(bannerId);

            Assert.That(result!.Id, Is.EqualTo(bannerId));

        }

        [Test]
        public async Task GetBannerByIdAsyncShouldReturnNull()
        {
            var bannerId = new Guid("01C582D3-63E5-41A5-BA3D-ACC4AFEC36FE");

            var result = await bannerService.GetBannerByIdAsync(bannerId);

            Assert.That(result == null);

        }


        [Test]
        public async Task GetBannerByIdAsyncShouldReturnBannerProp()
        {

            var banner = FakeData.BannerFormModels[1];

            var result = await bannerService.GetBannerByIdAsync(banner.Id);

            Assert.That(result!.Id, Is.EqualTo(banner.Id));
            Assert.That(result!.GameName, Is.EqualTo(banner.GameName));
            Assert.That(result!.BannerImageURL, Is.EqualTo(banner.BannerImageURL));
            Assert.That(result!.BannerTitle, Is.EqualTo(banner.BannerTitle));
            Assert.That(result!.Description, Is.EqualTo(banner.Description));
            Assert.That(result!.BannerURL, Is.EqualTo(banner.BannerURL));

        }

        [Test]
        public async Task GetBannersAsyncShouldReturnAllBanners()
        {
            var gameName = "TestGameName";

            var result = await bannerService.GetBannersAsync(gameName);

            Assert.That(result != null);

        }

    }
}
