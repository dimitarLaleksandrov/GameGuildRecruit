using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameGuildRecruit.Web.Services;
using GameGuildRecruit.Web.Services.Interfaces;

namespace GameGuildRecruit.Tests.UnitTests
{

    [TestFixture]
    public class GuildRecruitUserServiceTests : UnitTestsBase
    {
        private IGuildRecruitUserService _guildRecruitUserService;


        [OneTimeSetUp]
        public void SetUp()
        {
            _guildRecruitUserService = new GuildRecruitUserService(_data);

        }

    }

  

}
