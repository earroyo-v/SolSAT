using SAT.Infrastructure.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAT.Infrastructure.Mappers
{
    public static class ContribuyenteMapper
    {
        public static SAT.Domain.Domain.Contribuyente ToDomain(this Rfc user)
        {
            var domain = new SAT.Domain.Domain.Contribuyente(user.IdUser, user.Nombre, user.ApellidoPaterno, user.ApellidoMaterno, user.FechaNacimiento, user.Rfc1);
            return domain.Create();
        }

        public static Rfc ToEntity(this SAT.Domain.Domain.Contribuyente domain)
        {
            return new Rfc
            {
                IdUser = domain.IdUser,
                Nombre = domain.Nombre,
                ApellidoPaterno = domain.ApellidoPaterno,
                ApellidoMaterno = domain.ApellidoMaterno,
                FechaNacimiento = domain.FechaNacimiento,
                Rfc1 = domain.RFC
            };
        }
    }
}
