using Microsoft.AspNetCore.Mvc;

namespace WebElectionApp.Controllers
{
    public class CandidatosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
