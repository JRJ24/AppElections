using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sadvo.Application.DTOs.ElectivePositions;
using Sadvo.Application.Interfaces;

namespace WebElectionApp.Controllers
{
    public class ElectivePositionsController : Controller
    {
        private readonly ILogger<ElectivePositionsController> _logger;
        private readonly IElectivePositionsServices _electivePositionsService;
        private readonly IMapper _mapper;

        public ElectivePositionsController(ILogger<ElectivePositionsController> logger, IElectivePositionsServices electivePositionsService, IMapper mapper)
        {
            _logger = logger;
            _electivePositionsService = electivePositionsService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _electivePositionsService.GetAll();
            if (!result.success || result.data == null)
            {
                _logger.LogError("result.data es null o la operación no fue exitosa");
                return View(Enumerable.Empty<Sadvo.Application.ViewModels.ElectivePositions.ElectivePositionsViewModel>());
            }
            return View(result.data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SaveElectivePositionsDTO dto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("Modelo no válido");
                return View(dto);
            }
            var result = await _electivePositionsService.Save(dto);
            if (!result.success)
            {
                _logger.LogError("Error al crear la posición electoral: " + result.message);
                return View(dto);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
