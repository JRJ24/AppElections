using Microsoft.AspNetCore.Mvc;

namespace Sadvo.WebApp.Controllers
{
    public class HomeElectorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
