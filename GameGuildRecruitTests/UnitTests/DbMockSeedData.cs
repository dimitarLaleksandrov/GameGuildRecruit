using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameGuildRecruit.Web.Data.Models;

namespace GameGuildRecruit.Tests.UnitTests
{
    public static class DbMockSeedData
    {
        public static List<GuildRecruitUser> guildUsers = new List<GuildRecruitUser>() 
        { 
            new GuildRecruitUser()
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
            },
            new GuildRecruitUser()
            {
                Id = Guid.NewGuid(), // should ste auto
                NickName = "Avatar2",
                UrlLink = "TestUrl2",
                GuildName = "Test2",
                ServerName = "DiabloTest2",
                GameName = "Diablo",
                Description = "TestDescription2",
                UserName = "TestName2",
                UserAvatarPix = "MyPix2"
            }
        };


    }
}
