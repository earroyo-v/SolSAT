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
        [HttpGet("/")]
        public IActionResult Index()
        {            
            return View();
        }
        [HttpGet("/obtener-rfcs")]
        public async Task<IActionResult> GetRfc()
        {
            var response = await _contribuyenteService.ObtenerTodos();
            return Json(response);
        }
        [HttpPost("/crear-rfc")]
        public async Task<IActionResult> CreateRfc([FromBody] SAT.Application.Services.Contribuyente.DTO.ContribuyenteDTO contribuyente)
        {
            var response = await _contribuyenteService.CrearRFC(contribuyente);
            return Json(response);
        }
        [HttpPost]
        public async Task<IActionResult> EditRfc()
        {
            return Json(new { Rfc = "Your RFC here" });
        }
        [HttpPost]
        public async Task<IActionResult> DeleteRfc()
        {
            return Json(new { Rfc = "Your RFC here" });
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
