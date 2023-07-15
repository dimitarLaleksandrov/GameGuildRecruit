using GameGuildRecruit.Web.Models;
using GameGuildRecruit.Web.Services;
using GameGuildRecruit.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GameGuildRecruit.Web.Controllers
{
    public class HomeController : BaseController
    {

        private readonly IHomeService homeService;

        private readonly ILogger<HomeController> _logger;


        public HomeController(IHomeService homeService, ILogger<HomeController> logger)
        {
            this.homeService = homeService;
            _logger = logger;

        }



        public async Task<IActionResult> Index()
        {
            try
            {
                var gamesModels = await homeService.GetGamesAsync();

                return View(gamesModels);
            }
            catch (Exception)
            {
                return RedirectToAction("EmptyGuildInfo", "Errors");
            }
        }

        public async Task<IActionResult> Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}