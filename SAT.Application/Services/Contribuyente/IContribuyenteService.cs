using SAT.Application.Common;
using SAT.Application.Services.Contribuyente.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAT.Application.Services.Contribuyente
{
    public interface IContribuyenteService
    {
        public Task<Respuesta<ContribuyenteDTO>> CrearRFC(ContribuyenteDTO user);
        public Task<Respuesta<List<ContribuyenteDTO>>> ObtenerTodos();
        public Task<Respuesta<ContribuyenteDTO>> ActualizarRFC(ContribuyenteDTO user);
        public Task<Respuesta<bool>> EliminarRFC(int id);
        //List<E_RFC> ReadCustom(string data);
    }
}
