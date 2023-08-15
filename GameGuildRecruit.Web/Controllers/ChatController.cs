using Microsoft.AspNetCore.Mvc;

namespace GameGuildRecruit.Web.Controllers
{
    public class ChatController : Controller
    {


        public IActionResult ChatRoom()
        {
            return View();
        }
    }
}
