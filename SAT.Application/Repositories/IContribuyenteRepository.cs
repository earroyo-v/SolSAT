using SAT.Application.Services.Contribuyente.DTO;
using SAT.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAT.Application.Repositories
{
    public interface IContribuyenteRepository
    {
        public Task Create(Contribuyente user);
        public Task<List<ContribuyenteDTO>> ReadAll();
        //E_RFC ReadOne(int idUser);
        //List<E_RFC> ReadCustom(string data);
        //void Update(E_RFC user);
        //void Delete(int idUser);
        //int Count();
    }
}
