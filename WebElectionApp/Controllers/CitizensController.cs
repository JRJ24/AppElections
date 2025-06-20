using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sadvo.Application.DTOs.Citizens;
using Sadvo.Application.DTOs.Election;
using Sadvo.Application.Interfaces;
using Sadvo.Application.ViewModels.Citizens;

namespace WebElectionApp.Controllers
{
    public class CitizensController : Controller
    {

        private readonly ILogger<CitizensController> _logger;
        private readonly ICitizensServices _citizensService;
        private readonly IMapper _mapper;

        public CitizensController(ILogger<CitizensController> logger, ICitizensServices citizensService, IMapper mapper)
        {
            _logger = logger;
            _citizensService = citizensService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _citizensService.GetAll();
            if (!result.success || result.data == null)
            {
                _logger.LogError("result.data es null o la operación no fue exitosa");
                return View(Enumerable.Empty<CitizensViewModel>());
            }

            return View(result.data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SaveCitizensDTO citizes)
        {
            var result = await _citizensService.Save(citizes);

            if (!result.success) return View();

            return RedirectToAction(nameof(Index));
        }
    }
}
