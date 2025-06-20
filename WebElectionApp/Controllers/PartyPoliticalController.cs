using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sadvo.Application.DTOs.PartyPolitical;
using Sadvo.Application.Interfaces;
using Sadvo.Application.ViewModels.PartyPolitical;
using WebElectionApp.Helpers;
namespace WebElectionApp.Controllers
{
    public class PartyPoliticalController : Controller
    {
        private readonly ILogger<PartyPoliticalController> _logger;
        private readonly IPartyPoliticalService _partyPoliticalService;
        private readonly IMapper _mapper;

        public PartyPoliticalController(ILogger<PartyPoliticalController> logger, IPartyPoliticalService partyPoliticalService, IMapper mapper)
        {
            _logger = logger;
            _partyPoliticalService = partyPoliticalService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _partyPoliticalService.GetAll();
            if (!result.success || result.data == null)
            {
                _logger.LogError("result.data es null o la operación no fue exitosa");
                return View(Enumerable.Empty<PartyPoliticalViewModels>());
            }
            return View(result.data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SavePartyPoliticalDTO partyPolitical)
        {
            var result = await _partyPoliticalService.Save(partyPolitical);

            if (!result.success) return View();

            return RedirectToAction(nameof(Index));
        }

    }
}
