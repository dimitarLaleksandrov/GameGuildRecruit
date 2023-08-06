using GameGuildRecruit.Web.Data;
using GameGuildRecruit.Web.Services;
using GameGuildRecruit.Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGuildRecruit.Tests
{
    public class GuildRecruitUserTest
    {

        private IGuildRecruitUserService userService;

        private readonly GameGuildRecruitDbContext dbContext;


        [SetUp]
        public void Setup()
        {
            var mockedGuildRecruitUserService = new Mock<IGuildRecruitUserService>();

            mockedGuildRecruitUserService.Setup(x => x.GetNewUserModelAsync());


           userService = new GuildRecruitUserService(dbContext);
        }






    }
}
