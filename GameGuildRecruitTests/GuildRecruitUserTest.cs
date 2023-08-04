using GameGuildRecruit.Web.Data;
using GameGuildRecruit.Web.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGuildRecruitTests
{
    internal class GuildRecruitUserTest
    {

        private GuildRecruitUserService userService;

        private readonly GameGuildRecruitDbContext dbContext;


        [SetUp]
        public void Setup()
        {
            userService = new GuildRecruitUserService(dbContext);
        }



        [Test]

        public void 



    }
}
