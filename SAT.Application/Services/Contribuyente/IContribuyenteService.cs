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
        //List<E_RFC> ReadAll();
        //E_RFC ReadOne(int idUser);
        //List<E_RFC> ReadCustom(string data);
        //void Update(E_RFC user);
        //void Delete(int idUser);
        //int Count();
    }
}
