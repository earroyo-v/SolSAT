using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SAT.Application.Services.Contribuyente;
using SAT.Presentation.Web.Models;

namespace SAT.Presentation.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContribuyenteService _contribuyenteService;

        public HomeController(ILogger<HomeController> logger, IContribuyenteService contribuyenteService)
        {
            _logger = logger;
            _contribuyenteService = contribuyenteService;
        }

        public async Task<IActionResult> Index()
        {
            await _contribuyenteService.CrearRFC(new SAT.Application.Services.Contribuyente.DTO.ContribuyenteDTO
            {
                IdUser = 0,
                Nombre = "Juan",
                ApellidoPaterno = "Perez",
                ApellidoMaterno = "Gomez",
                FechaNacimiento = new DateTime(1990, 1, 1),
                RFC = null
            });
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
