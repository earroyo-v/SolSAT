using Microsoft.EntityFrameworkCore;
using SAT.Application.Services.Contribuyente;
using SAT.Application.Services.Contribuyente.DTO;
using SAT.Infrastructure.Implementation;
using SAT.Infrastructure.Persistence.Data;

namespace SAT.Application.Tests
{
    public class ContribuyenteServiceIntegrationTest
    {
        private readonly ContribuyenteService _service;
        private readonly ContribuyenteImp _repo;
        private readonly AppDbContext _context;

        public ContribuyenteServiceIntegrationTest()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer("Server=.;Database=GENERACION33;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;
            _context = new AppDbContext(options);

            _repo = new ContribuyenteImp(_context);
            _service = new ContribuyenteService(_repo);
        }

        [Fact]
        public async Task CrearRFC_GeneraYPersisteRfc()
        {
            var dto = new ContribuyenteDTO
            {
                IdUser = 0,
                Nombre = "Juan",
                ApellidoPaterno = "Perez",
                ApellidoMaterno = "Gomez",
                FechaNacimiento = new DateTime(1990, 1, 1),
                RFC = null
            };

            await _service.CrearRFC(dto);

            var saved = await _context.Rfcs.FirstOrDefaultAsync(r => r.Nombre == "Juan" && r.ApellidoPaterno == "Perez");
            Assert.NotNull(saved);
            Assert.False(string.IsNullOrEmpty(saved.Rfc1));
        }
    }
}