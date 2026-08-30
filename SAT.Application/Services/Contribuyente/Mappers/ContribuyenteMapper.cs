using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAT.Application.Services.Contribuyente.Mappers
{
    public static class ContribuyenteMapper
    {
        public static SAT.Domain.Domain.Contribuyente ToDomain(this DTO.ContribuyenteDTO dto)
        {
            SAT.Domain.Domain.Contribuyente domain = new SAT.Domain.Domain.Contribuyente(dto.IdUser, dto.Nombre, dto.ApellidoPaterno, dto.ApellidoMaterno, dto.FechaNacimiento, dto.RFC);
            return domain.Create();
        }
        public static DTO.ContribuyenteDTO ToDTO(this SAT.Domain.Domain.Contribuyente domain)
        {
            return new DTO.ContribuyenteDTO
            {
                IdUser = domain.IdUser,
                Nombre = domain.Nombre,
                ApellidoPaterno = domain.ApellidoPaterno,
                ApellidoMaterno = domain.ApellidoMaterno,
                FechaNacimiento = domain.FechaNacimiento,
                RFC = domain.RFC
            };
        }
    }
}
