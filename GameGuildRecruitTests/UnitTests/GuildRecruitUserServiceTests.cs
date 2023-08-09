using GameGuildRecruit.Web.Data;
using GameGuildRecruit.Web.Data.Models;
using Microsoft.EntityFrameworkCore;
using Moq.Language.Flow;
using System.ComponentModel;
using Moq;
using Moq.EntityFrameworkCore;
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

       
    } 

}
