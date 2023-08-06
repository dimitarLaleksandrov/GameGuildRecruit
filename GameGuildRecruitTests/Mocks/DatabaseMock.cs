using GameGuildRecruit.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGuildRecruit.Tests.Mocks
{
    public class DatabaseMock
    {

        public static GameGuildRecruitDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<GameGuildRecruitDbContext>()
                    .UseInMemoryDatabase("GameGuildRecruitInMemoryDb" + DateTime.Now.Ticks.ToString())
                    .Options;


                return new GameGuildRecruitDbContext(dbContextOptions, false);

            }
        }
    }
}
