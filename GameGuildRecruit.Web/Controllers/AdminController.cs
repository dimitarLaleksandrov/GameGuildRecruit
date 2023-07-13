using Microsoft.AspNetCore.Mvc;

namespace GameGuildRecruit.Web.Controllers
{
    public class AdminController : BaseController
    {
        public IActionResult AdminView()
        {
            return View();
        }
    }
}
