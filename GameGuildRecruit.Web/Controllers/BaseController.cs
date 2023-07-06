using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GameGuildRecruit.Web.Controllers
{
    public class BaseController : Controller
    {
        protected Guid GetUserId()
        {
            string id = string.Empty;

            if (User != null)
            {
                id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            var guidId = new Guid(id);
            return guidId;
        }
    }
}
