using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using GameGuildRecruit.Web.Data;
using GameGuildRecruit.Web.Data.Models;

namespace GameGuildRecruit.Tests.UnitTests
{
    public static class DataBaseSeeder
    {
        private static GuildRecruitUser GuildRecruitUser;


        public static void SeedDataBase(GameGuildRecruitDbContext dbContext)
        {
            GuildRecruitUser = new GuildRecruitUser()             
            {
                Id = Guid.NewGuid(), // should ste auto
                NickName = "Avatar",
                UrlLink = "TestUrl",
                GuildName = "Test",
                ServerName = "DiabloTest",
                GameName = "Diablo",
                Description = "TestDescription",
                UserName = "TestName",
                UserAvatarPix = "MyPix"
            };
            dbContext.GuildRecruitUsers.Add(GuildRecruitUser);

            dbContext.SaveChanges();
        }



    }
}
