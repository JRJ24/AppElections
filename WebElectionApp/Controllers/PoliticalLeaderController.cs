using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sadvo.Application.Interfaces;

namespace WebElectionApp.Controllers
{
    public class PoliticalLeaderController : Controller
    {
        private readonly ILogger<PoliticalLeaderController> _logger;
        private readonly IPoliticalLeaderServices _politicalLeaderService;
        private readonly IMapper _mapper;

        public PoliticalLeaderController(
            ILogger<PoliticalLeaderController> logger,
            IPoliticalLeaderServices politicalLeaderService,
            IMapper mapper)
        {
            _logger = logger;
            _politicalLeaderService = politicalLeaderService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _politicalLeaderService.GetAll();
            if (!result.success || result.data == null)
            {
                _logger.LogError("result.data es null o la operación no fue exitosa");
                return View(Enumerable.Empty<Sadvo.Application.ViewModels.PoliticalLeader.PoliticalLeaderViewModel>());
            }

            return View(result.data);
        }
    }
}
