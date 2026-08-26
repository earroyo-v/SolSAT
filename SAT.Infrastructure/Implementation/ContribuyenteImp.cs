using SAT.Application.Repositories;
using SAT.Domain.Domain;
using SAT.Infrastructure.Persistence.Data;
using SAT.Infrastructure.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAT.Infrastructure.Implementation
{
    public class ContribuyenteImp : IContribuyenteRepository
    {
        private readonly AppDbContext _context;
        public ContribuyenteImp(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Contribuyente user)
        {
            try
            {
                var rfc = new Rfc
                {
                    Nombre = user.Nombre,
                    ApellidoPaterno = user.ApellidoPaterno,
                    ApellidoMaterno = user.ApellidoMaterno,
                    FechaNacimiento = user.FechaNacimiento,
                    Rfc1 = user.RFC
                };
                _context.Add(rfc);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Error al crear el contribuyente");
            }
        }
    }
}
