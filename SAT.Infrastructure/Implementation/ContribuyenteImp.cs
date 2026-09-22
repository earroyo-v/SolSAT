using Microsoft.EntityFrameworkCore;
using SAT.Application.Repositories;
using SAT.Application.Services.Contribuyente.DTO;
using SAT.Domain.Domain;
using SAT.Infrastructure.Mappers;
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
                var rfc = user.ToEntity();
                _context.Add(rfc);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Error al crear el contribuyente");
            }
        }

        public async Task<List<ContribuyenteDTO>> ReadAll()
        {
            try
            {
                var rfcs = await _context.Rfcs.AsNoTracking().ToListAsync();
                return rfcs.Select(r => r.ToDTO()).ToList();
                //return rfcs.Select(r => r.ToDomain()).ToList();
            }
            catch
            {
                throw new Exception("Error al crear el contribuyente");
            }
        }
    }
}
