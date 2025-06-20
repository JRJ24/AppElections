using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sadvo.Application.DTOs.Election;
using Sadvo.Application.Interfaces;
using Sadvo.Application.ViewModels.Election;


namespace WebElectionApp.Controllers
{
    public class ElectionController : Controller
    {
        private readonly ILogger<ElectionController> _logger;
        private readonly IElectionService _electionService;
        private readonly IMapper _mapper;

        public ElectionController(ILogger<ElectionController> logger, IElectionService electionService, IMapper mapper)
        {
            _logger = logger;
            _electionService = electionService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _electionService.GetAll();
            if (!result.success || result.data == null)
            {
                _logger.LogError("result.data es null o la operación no fue exitosa");
                return View(Enumerable.Empty<ElectionViewModel>());
            }
            return View(result.data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SaveElectionDTO election)
        {
            var result = await _electionService.Save(election);

            if (!result.success) return View();

            return RedirectToAction(nameof(Index));
        }

    }
}
