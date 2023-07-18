using GameGuildRecruit.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameGuildRecruit.Web.Controllers
{
    public class AvatarController : BaseController
    {

        private readonly IAvatarService avatarService;


        public AvatarController(IAvatarService avatarService)
        {
            this.avatarService = avatarService;

        }



        public IActionResult Index()
        {
            return View();
        }
    }
}
