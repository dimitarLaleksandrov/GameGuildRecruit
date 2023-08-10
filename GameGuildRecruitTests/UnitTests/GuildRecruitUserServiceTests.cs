using GameGuildRecruit.Web.Data;
using GameGuildRecruit.Web.Data.Models;
using Microsoft.EntityFrameworkCore;
using Moq.Language.Flow;
using static GameGuildRecruit.Tests.UnitTests.DataBaseSeeder;
using GameGuildRecruit.Web.Services.Interfaces;
using GameGuildRecruit.Web.Services;
using GameGuildRecruit.Web.ViewModels.GuildRecruitUser;
using GameGuildRecruit.Tests.Mocks;

namespace GameGuildRecruit.Tests.UnitTests
{

    [TestFixture]
    public class GuildRecruitUserServiceTests
    {

        private DbContextOptions<GameGuildRecruitDbContext> dbOptions;
        private GameGuildRecruitDbContext dbContext;

        private IGuildRecruitUserService guildRecruitUserService;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            dbOptions = new DbContextOptionsBuilder<GameGuildRecruitDbContext>()
               .UseInMemoryDatabase("GameGuildRecruitInMemoryDb" + Guid.NewGuid().ToString())
               .Options;
            
            dbContext = new GameGuildRecruitDbContext(dbOptions);

            dbContext.Database.EnsureCreated();

            SeedDataBase(dbContext);

            guildRecruitUserService = new GuildRecruitUserService(dbContext);

        }



        [Test]
        public async Task GetUserByUserNameAsyncShouldReturnUser()
        {
           
            var expected = FakeData.GuildRecruitUsers[0];

            var result = await guildRecruitUserService.GetUserByUserNameAsync(expected.UserName!);

            Assert.That(expected.Id, Is.EqualTo(result!.Id));

        }

        [Test]
        public async Task GetUserByUserNameAsyncShouldReturnNull()
        {

            string expected = null!;

            var result = await guildRecruitUserService.GetUserByUserNameAsync(expected);

            Assert.That(result == null);

        }


        [Test]
        public async Task EditUserAsyncShouldEditUser()
        {

            var userName = "TestName";
            var user = FakeData.GuildRecruitUserFormModel[0];


            await guildRecruitUserService.EditUserAsync(user, userName);

            var result = await guildRecruitUserService.GetUserByUserNameAsync(userName);


            Assert.That(user.Id, Is.EqualTo(result!.Id));

        }

        [Test]
        public async Task EditUserAsyncShouldReturnNull()
        {

            string userName = null!;

            var user = FakeData.GuildRecruitUserFormModel[0];

            await guildRecruitUserService.EditUserAsync(user, userName);

            var result = await guildRecruitUserService.GetUserByUserNameAsync(userName);


            Assert.That(result == null);

        }

        [Test]
        public async Task EditUserAsyncShouldReturnUserProp()
        {

            var userName = "TestName";

            var user = FakeData.GuildRecruitUserFormModel[0];

            await guildRecruitUserService.EditUserAsync(user, userName);

            var result = await guildRecruitUserService.GetUserByUserNameAsync(userName);

            Assert.That(user.Id, Is.EqualTo(result!.Id));
            Assert.That(user.NickName, Is.EqualTo(result!.NickName));
            Assert.That(user.UrlLink, Is.EqualTo(result!.UrlLink));
            Assert.That(user.GuildName, Is.EqualTo(result!.GuildName));
            Assert.That(user.ServerName, Is.EqualTo(result!.ServerName));
            Assert.That(user.GameName, Is.EqualTo(result!.GameName));
            Assert.That(user.Description, Is.EqualTo(result!.Description));
            Assert.That(user.UserName, Is.EqualTo(result!.UserName));


        }

        [Test]
        public async Task GetUserByUserNameAsyncShouldReturnUserProp()
        {

            var expected = FakeData.GuildRecruitUsers[0];

            var result = await guildRecruitUserService.GetUserByUserNameAsync(expected.UserName!);

            Assert.That(expected.Id, Is.EqualTo(result!.Id));
            Assert.That(expected.NickName, Is.EqualTo(result!.NickName));
            Assert.That(expected.UrlLink, Is.EqualTo(result!.UrlLink));
            Assert.That(expected.GuildName, Is.EqualTo(result!.GuildName));
            Assert.That(expected.ServerName, Is.EqualTo(result!.ServerName));
            Assert.That(expected.GameName, Is.EqualTo(result!.GameName));
            Assert.That(expected.Description, Is.EqualTo(result!.Description));
            Assert.That(expected.UserName, Is.EqualTo(result!.UserName));
            Assert.That(expected.UserAvatarPix, Is.EqualTo(result!.UserAvatarPix));

        }

        [Test]
        public async Task AddUserAsyncShouldAddUserInDb()
        {

            var user = FakeData.GuildRecruitUserFormModel[0];


            var userName = "TestName";

            var id = new Guid("5D67F493-07F1-420E-9284-4A1802C7D342");

            await guildRecruitUserService.AddUserAsync(user, userName, id);

            Assert.That(dbContext.GuildRecruitUsers.Count() == 4);

        }

        [Test]
        public async Task GetUserByUserNameForIdAsyncShouldReturnUser()
        {

            var userName = "TestName1";
            var id = new Guid("4BFC818A-EBCD-459A-B1B9-756AC08F0EFA");

            var result = await guildRecruitUserService.GetUserByUserNameForIdAsync(userName);

            Assert.That(result.Id, Is.EqualTo(id));

        }

        [Test]
        public async Task GetUserByUserNameForIdAsyncShouldReturnNull()
        {

            var userName = "Tes";
            var id = new Guid("4BFC818A-EBCD-459A-B1B9-756AC08F0EFA");

            var result = await guildRecruitUserService.GetUserByUserNameForIdAsync(userName);

            Assert.That(result == null);

        }


        [Test]
        public async Task GetMyContactsByIdAsyncShouldReturnContact()
        {

            var useId = new Guid("1D67F493-0FF1-420E-9284-4A1802C7D342");

            var result = await guildRecruitUserService.GetMyContactsByIdAsync(useId);

            var contacts = result.ToArray();

            Assert.That(contacts[0].GuildUserId, Is.EqualTo(useId));

        }


       





    } 

}
