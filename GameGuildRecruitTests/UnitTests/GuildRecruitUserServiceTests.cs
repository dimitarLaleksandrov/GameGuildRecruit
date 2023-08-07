using GameGuildRecruit.Web.Data;
using GameGuildRecruit.Web.Data.Models;
using Microsoft.EntityFrameworkCore;
using Moq.Language.Flow;
using System.ComponentModel;
using Moq;
using Moq.EntityFrameworkCore;
using static GameGuildRecruit.Tests.UnitTests.DbMockSeedData;
using static GameGuildRecruit.Tests.UnitTests.DataBaseSeeder;
using GameGuildRecruit.Web.Services.Interfaces;
using GameGuildRecruit.Web.Services;
using GameGuildRecruit.Web.ViewModels.GuildRecruitUser;

namespace GameGuildRecruit.Tests.UnitTests
{

    [TestFixture]
    public class GuildRecruitUserServiceTests : UnitTestsBase
    {

        private DbContextOptions<GameGuildRecruitDbContext> dbOptions;
        private GameGuildRecruitDbContext dbContext;

        private IGuildRecruitUserService guildRecruitUserService;

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

            guildRecruitUserService = new GuildRecruitUserService(dbContext);

        }

        [SetUp]
        public void Setup() 
        { 

        }


        [Test]
        public async Task GetUserByUserNameAsyncShouldReturnUser()
        {
            //dbMock = new Mock<GameGuildRecruitDbContext>()
            //      .Setup(db => db.GuildRecruitUsers)
            //      .ReturnsDbSet(guildUsers);


     
             
            string existingUserName = GuildRecruitUser.UserName!;

            var user = dbContext.GuildRecruitUsers
                                .Where(u => u.UserName == existingUserName)
                                .Select(u => new GuildRecruitUserViewModel() 
                                {
                                    Id = u.Id,
                                    NickName = u.NickName,
                                    UrlLink = u.UrlLink,
                                    GuildName = u.GuildName,
                                    ServerName = u.ServerName,
                                    GameName = u.GameName,
                                    Description = u.Description,
                                    UserName = u.UserName,
                                    UserAvatarPix = u.UserAvatarPix
                                });



            var result = await guildRecruitUserService.GetUserByUserNameAsync(existingUserName);

            Assert.AreEqual(result, user);


        }

       
    } 

}
