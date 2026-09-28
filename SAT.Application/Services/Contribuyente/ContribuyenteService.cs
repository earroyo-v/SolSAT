using SAT.Application.Common;
using SAT.Application.Repositories;
using SAT.Application.Services.Contribuyente.DTO;
using SAT.Application.Services.Contribuyente.Mappers;
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
        private readonly IContribuyenteRepository _contribuyenteRepository;
        public ContribuyenteService(IContribuyenteRepository contribuyenteRepository)
        {
            _contribuyenteRepository = contribuyenteRepository;
        }
        public async Task<Respuesta<List<ContribuyenteDTO>>> ObtenerTodos()
        {
            var dominios = await _contribuyenteRepository.ReadAll();
            //var dtos = dominios.Select(d => d.ToDTO()).ToList(); // o usar AutoMapper
            return new Respuesta<List<ContribuyenteDTO>>
            {
                Exito = true,
                Mensaje = "Lista recuperada",
                //Item = dtos
                Item = dominios
            };
        }
        public async Task<Respuesta<ContribuyenteDTO>> CrearRFC(ContribuyenteDTO user)
        {
            if (user is null)
            {
                return new Respuesta<ContribuyenteDTO>
                {
                    Exito = false,
                    Mensaje = "Datos de contribuyente inválidos.",
                    Error = "El objeto ContribuyenteDTO es nulo."
                };
            }
            try
            {
                // Se asume que el tipo correcto es SAT.Domain.Domain.Contribuyente
                var rfc = user.ToDomain();
                // Act
                rfc.GenerarRfc();

                await _contribuyenteRepository.Create(rfc);

                return new Respuesta<ContribuyenteDTO>
                {
                    Exito = true,
                    Item = rfc.ToDTO(),
                    Mensaje = "Contribuyente creado exitosamente"
                };
            }
            catch
            {
                return new Respuesta<ContribuyenteDTO>
                {
                    Exito = false,
                    Mensaje = "Error al crear el contribuyente",
                    Error = "No fue posible registrar el contribuyente."
                };
            }
        }

        public async Task<Respuesta<ContribuyenteDTO>> ActualizarRFC(ContribuyenteDTO user)
        {
            if (user is null)
            {
                return new Respuesta<ContribuyenteDTO>
                {
                    Exito = false,
                    Mensaje = "Datos de contribuyente inválidos.",
                    Error = "El objeto ContribuyenteDTO es nulo."
                };
            }
            try
            {
                // Se asume que el tipo correcto es SAT.Domain.Domain.Contribuyente
                var rfc = user.ToDomain();
                // Act
                rfc.GenerarRfc();

                await _contribuyenteRepository.Update(rfc);

                return new Respuesta<ContribuyenteDTO>
                {
                    Exito = true,
                    Item = rfc.ToDTO(),
                    Mensaje = "Contribuyente creado exitosamente"
                };
            }
            catch
            {
                return new Respuesta<ContribuyenteDTO>
                {
                    Exito = false,
                    Mensaje = "Error al crear el contribuyente",
                    Error = "No fue posible registrar el contribuyente."
                };
            }
        }

        public async Task<Respuesta<bool>> EliminarRFC(int id)
        {
            try
            {
                await _contribuyenteRepository.Delete(id);
                return new Respuesta<bool>
                {
                    Exito = true,
                    Item = true,
                    Mensaje = "Contribuyente eliminado exitosamente"
                };
            }
            catch
            {
                return new Respuesta<bool>
                {
                    Exito = false,
                    Item = false,
                    Mensaje = "Error al eliminar el contribuyente",
                    Error = "No fue posible eliminar el contribuyente."
                };
            }
        }
    }
}
