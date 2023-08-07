using GameGuildRecruit.Web.Data;
using GameGuildRecruit.Web.Data.Models;
using Microsoft.EntityFrameworkCore;
using Moq.Language.Flow;
using System.ComponentModel;
using Moq;
using Moq.EntityFrameworkCore;
using static GameGuildRecruit.Tests.UnitTests.DbMockSeedData;
using static GameGuildRecruit.Tests.UnitTests.DataBaseSeeder;

namespace GameGuildRecruit.Tests.UnitTests
{

    [TestFixture]
    public class GuildRecruitUserServiceTests : UnitTestsBase
    {

        private DbContextOptions<GameGuildRecruitDbContext> dbOptions;
        private GameGuildRecruitDbContext dbContext;

        private IReturnsResult<GameGuildRecruitDbContext> dbMock;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            dbOptions = new DbContextOptionsBuilder<GameGuildRecruitDbContext>()
               .UseInMemoryDatabase("GameGuildRecruitInMemoryDb" + Guid.NewGuid().ToString())
               .Options;
            
            dbContext = new GameGuildRecruitDbContext(dbOptions);

            dbContext.Database.EnsureCreated();

            SeedDataBase(dbContext);

        }

        [SetUp]
        public void Setup() 
        { 

        }


        [Test]
        public void GetUserByUserNameAsyncShouldReturnUser()
        {
            //dbMock = new Mock<GameGuildRecruitDbContext>()
            //      .Setup(db => db.GuildRecruitUsers)
            //      .ReturnsDbSet(guildUsers);


     


            


        }

       
    } 

}
