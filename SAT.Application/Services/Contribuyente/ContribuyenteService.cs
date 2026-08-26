using SAT.Application.Repositories;
using SAT.Application.Services.Contribuyente.DTO;
using SAT.Domain.Domain
    ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SAT.Application.Services.Contribuyente
{
    public class ContribuyenteService : IContribuyenteService
    {
        IContribuyenteRepository _contribuyenteRepository;
        public ContribuyenteService(IContribuyenteRepository contribuyenteRepository)
        {
            _contribuyenteRepository = contribuyenteRepository;
        }
        public async Task CrearRFC(ContribuyenteDTO user)
        {
            try
            {
                // Se asume que el tipo correcto es SAT.Domain.Domain.Contribuyente
                var rfc = new SAT.Domain.Domain.Contribuyente(
                    0,
                    user.Nombre,
                    user.ApellidoPaterno,
                    user.ApellidoMaterno,
                    user.FechaNacimiento,
                    null
                );
                // Act
                rfc.GenerarRfc();

                await _contribuyenteRepository.Create(rfc);
            }
            catch
            {
                throw new Exception("Error al crear el contribuyente");
            }
        }
    }
}
