using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using GameGuildRecruit.Tests.Mocks;
using GameGuildRecruit.Web.Data;
using GameGuildRecruit.Web.Data.Models;

namespace GameGuildRecruit.Tests.UnitTests
{
    public static class DataBaseSeeder
    {
        

        public static void SeedDataBase(GameGuildRecruitDbContext dbContext)
        {
            
            dbContext.GuildRecruitUsers.AddRange(FakeData.GuildRecruitUsers.ToArray());

            dbContext.ContactPlayers.AddRange(FakeData.ContactPlayers.ToArray());

            dbContext.Games.AddRange(FakeData.Games.ToArray());

            dbContext.Banners.AddRange(FakeData.Banners.ToArray());

            dbContext.Avatars.AddRange(FakeData.Avatars.ToArray());


            dbContext.SaveChanges();
        }



    }
}
