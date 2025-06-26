using Microsoft.AspNetCore.Mvc;
using Projeto_SCFII.Infrastructure.Application.Constructors.Services;
using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;

namespace Projeto_SCFII.Controllers
{
    public class CargoController : Controller
    {
        private readonly ICargoService _cargoService;
        private readonly ILogger<CargoController> _logger;

        public CargoController(ICargoService cargoService, ILogger<CargoController> logger)
        {
            _cargoService = cargoService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _cargoService.GetAllAsync();

            if (!response.Success)
            {
                TempData["Erro"] = response.Message;
                return View(new List<Cargo>());
            }

            return View(response.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var response = await _cargoService.GetByIdAsync(id);

            if (!response.Success || response.Data == null)
            {
                TempData["Erro"] = response.Message;
                return RedirectToAction("Index");
            }

            return View(response.Data);
        }
    }
}
