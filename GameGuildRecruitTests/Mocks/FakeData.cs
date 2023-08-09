using GameGuildRecruit.Web.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GameGuildRecruit.Tests.Mocks
{
    public static class FakeData
    {
        public static List<GuildRecruitUser> GuildRecruitUsers => new List<GuildRecruitUser>() 
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
            }
        
        };

    }
}
