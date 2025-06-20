using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sadvo.Application.DTOs.RolUsers;
using Sadvo.Application.Interfaces;
using Sadvo.Application.ViewModels.RolUser;

namespace WebElectionApp.Controllers
{
    public class RolUsersController : Controller
    {
        private readonly ILogger<RolUsersController> _logger;
        private readonly IRolUserService _rolUserService;
        private readonly IMapper _mapper;

        public RolUsersController(ILogger<RolUsersController> logger, IRolUserService rolUserService, IMapper mapper)
        {
            _logger = logger;
            _rolUserService = rolUserService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _rolUserService.GetAll();
            if (!result.success || result.data == null)
            {
                _logger.LogError("result.data es null o la operación no fue exitosa");
                return View(Enumerable.Empty<RolUserViewModel>());
            }
            return View(result.data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SaveRolUsersDTO rolUser)
        {
            var result = await _rolUserService.Save(rolUser);
            if (!result.success) return View();
            return RedirectToAction(nameof(Index));
        }
    }
}
