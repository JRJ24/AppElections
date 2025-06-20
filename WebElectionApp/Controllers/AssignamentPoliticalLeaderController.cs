using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sadvo.Application.DTOs.PoliticalLeader;
using Sadvo.Application.Interfaces;
using Sadvo.Application.Services;
using Sadvo.Application.ViewModels.Citizens;
using Sadvo.Application.ViewModels.PoliticalLeader;

namespace WebElectionApp.Controllers
{
    public class AssignamentPoliticalLeaderController : Controller
    {
        private readonly ILogger<AssignamentPoliticalLeaderController> _logger;
        private readonly IPoliticalLeaderServices _politicalLeaderServices;
        private readonly IMapper _mapper;

        public AssignamentPoliticalLeaderController(ILogger<AssignamentPoliticalLeaderController> logger, IPoliticalLeaderServices politicalLeaderServices, IMapper mapper)
        {
            _logger = logger;
            _politicalLeaderServices = politicalLeaderServices;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _politicalLeaderServices.GetAll();
            if (!result.success || result.data == null)
            {
                _logger.LogError("result.data es null o la operación no fue exitosa");
                return View(Enumerable.Empty<PoliticalLeaderViewModel>());
            }

            return View(result.data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SavePoliticalLeaderDTO politicalLeader)
        {
            var result = await _politicalLeaderServices.Save(politicalLeader);
            if (!result.success) return View();
            return RedirectToAction(nameof(Index));
        }
    }
}
