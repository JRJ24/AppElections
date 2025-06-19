using Microsoft.AspNetCore.Mvc;

namespace Sadvo.WebApp.Controllers
{
    public class HomePoliticalLeaderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
