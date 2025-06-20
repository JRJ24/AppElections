using Microsoft.AspNetCore.Mvc;

namespace WebElectionApp.Controllers
{
    public class ElectorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
