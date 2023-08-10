using GameGuildRecruit.Web.Data;
using GameGuildRecruit.Web.Services.Interfaces;
using GameGuildRecruit.Web.Services;
using Microsoft.EntityFrameworkCore;
using static GameGuildRecruit.Tests.UnitTests.DataBaseSeeder;
using GameGuildRecruit.Web.ViewModels.Banner;
using GameGuildRecruit.Web.ViewModels.Avatar;
using GameGuildRecruit.Tests.Mocks;

namespace GameGuildRecruit.Tests.UnitTests
{

    [TestFixture]
    public class AvatarServiceTests
    {
        private DbContextOptions<GameGuildRecruitDbContext> dbOptions;
        private GameGuildRecruitDbContext dbContext;

        private IAvatarService avatarService;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            dbOptions = new DbContextOptionsBuilder<GameGuildRecruitDbContext>()
               .UseInMemoryDatabase("GameGuildRecruitInMemoryDb" + Guid.NewGuid().ToString())
               .Options;

            dbContext = new GameGuildRecruitDbContext(dbOptions);

            dbContext.Database.EnsureCreated();

            SeedDataBase(dbContext);

            avatarService = new AvatarService(dbContext);

        }

        [Test]
        public async Task AddAvatarAsyncShouldAddAvatarInDb()
        {
            var avatarId = new Guid("01F52ED3-63E5-41A5-BA3D-ACC4AFEC36FE");

            var newAvatar = new AvatarFormModel()
            {
                Name = "TestName2",
                AvatarPixURL = "TestAvatarPixURL2"
            };

            await avatarService.AddAvatarAsync(newAvatar, avatarId);

            Assert.That(dbContext.Banners.Count() == 3);

        }

        [Test]
        public async Task GetAvatarByIdAsyncShouldReturnAvatar()
        {
            var avatarId = new Guid("01C588D3-63E5-41A5-BA3D-ACC4AFEC36FE");

            var result = await avatarService.GetAvatarByIdAsync(avatarId);

            Assert.That(result!.Id, Is.EqualTo(avatarId));

        }

        [Test]
        public async Task GetAvatarByIdAsyncShouldReturnNull()
        {
            var avatarId = new Guid("01C528D3-63E5-41A5-BA3D-ACC4AFEC36FE");

            var result = await avatarService.GetAvatarByIdAsync(avatarId);

            Assert.That(result == null);

        }


        [Test]
        public async Task GetAvatarByIdAsyncShouldReturnAvatarProp()
        {

            var avatar = FakeData.AvatarFormModel[1];

            var result = await avatarService.GetAvatarByIdAsync(avatar.Id);

            Assert.That(result!.Id, Is.EqualTo(avatar.Id));
            Assert.That(result!.Name, Is.EqualTo(avatar.Name));
            Assert.That(result!.AvatarPixURL, Is.EqualTo(avatar.AvatarPixURL));

        }

        [Test]
        public async Task GetAvatarForSelectByIdAsyncShouldReturnAvatar()
        {
            var avatarId = new Guid("01C588D3-63E5-41A5-BA3D-ACC4AFEC36FE");

            var result = await avatarService.GetAvatarForSelectByIdAsync(avatarId);

            Assert.That(result!.Id, Is.EqualTo(avatarId));

        }

        [Test]
        public async Task GetAvatarForSelectByIdAsyncShouldReturnNull()
        {
            var avatarId = new Guid("01C528D3-63E5-41A5-BA3D-ACC4AFEC36FE");

            var result = await avatarService.GetAvatarForSelectByIdAsync(avatarId);

            Assert.That(result == null);

        }


        [Test]
        public async Task GetAvatarForSelectByIdAsyncShouldReturnAvatarProp()
        {

            var avatar = FakeData.AvatarViewModel[1];

            var result = await avatarService.GetAvatarByIdAsync(avatar.Id);

            Assert.That(result!.Id, Is.EqualTo(avatar.Id));
            Assert.That(result!.Name, Is.EqualTo(avatar.Name));
            Assert.That(result!.AvatarPixURL, Is.EqualTo(avatar.AvatarPixURL));

        }
    }
}
