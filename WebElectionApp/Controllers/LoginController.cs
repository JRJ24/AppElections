using Microsoft.AspNetCore.Mvc;
using Sadvo.Application.Interfaces;
using System.Diagnostics;

namespace WebElectionApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IUserServices _userServices;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View();
        }
    }
}
