using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sadvo.Application.DTOs.Users;
using Sadvo.Application.Interfaces;
using Sadvo.Application.ViewModels.Users;
using System.Diagnostics;
using System.Threading.Tasks;
using WebElectionApp.Models;

namespace WebElectionApp.Controllers
{
    public class UsersController : Controller
    {

        private readonly ILogger<UsersController> _logger;
        private readonly IUserServices _userService;
        private readonly IMapper _mapper;

        public UsersController(ILogger<UsersController> logger, IUserServices userService, IMapper mapper)
        {
            _logger = logger;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _userService.GetAll();
            if (!result.success || result.data == null)
            {
                // Puedes loguear aquí el tipo de result.data para depurar
                _logger.LogError("result.data es null o la operación no fue exitosa");
                return View(Enumerable.Empty<UsersViewModel>());
            }

            // Verifica el tipo de result.data
            //if (result.data is not IEnumerable<UsersViewModel>)
            //{
            //    _logger.LogError($"Tipo inesperado en result.data: {result.data.GetType()}");
            //    return View(Enumerable.Empty<UsersViewModel>());
            //}

            return View(result.data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SaveUsersDTO user)
        {
            var result = await _userService.Save(user);
            if (!result.success)
            {

            }
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
