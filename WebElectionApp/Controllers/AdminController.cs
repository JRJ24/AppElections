using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebElectionApp.Controllers
{
    public class AdminController : Controller
    {

        private readonly ILogger<AdminController> _logger;

        public ActionResult Index()
        {
            return View();
        }

    }
}
