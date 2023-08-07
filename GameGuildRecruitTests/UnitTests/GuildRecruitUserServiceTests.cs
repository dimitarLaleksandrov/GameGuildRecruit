using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameGuildRecruit.Web.Data;
using GameGuildRecruit.Web.Data.Models;
using GameGuildRecruit.Web.Services;
using GameGuildRecruit.Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;

namespace GameGuildRecruit.Tests.UnitTests
{

    [TestFixture]
    public class GuildRecruitUserServiceTests : UnitTestsBase
    {

        private DbContextOptions<GameGuildRecruitDbContext> dbOptions;
        private GameGuildRecruitDbContext dbContext;

        private Mock<GameGuildRecruitDbContext> dbMock;


        [OneTimeSetUp]
        public void SetUp()
        {
            dbOptions = new DbContextOptionsBuilder<GameGuildRecruitDbContext>()
               .UseInMemoryDatabase("GameGuildRecruitInMemoryDb" + Guid.NewGuid().ToString())
               .Options;

            dbContext = new GameGuildRecruitDbContext(dbOptions);

        }


        [Test]
        public void GetUserByUserNameAsyncShouldReturnUser()
        {
            var mock = new Mock<GameGuildRecruitDbContext>()
                  .Setup(db => db.GuildRecruitUsers)
                  .ReturnsDbSet(new List<GuildRecruitUser>()
                  {


                  });




        }


    } 

}
