using Microsoft.AspNetCore.Mvc;

namespace Sadvo.WebApp.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {

        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
