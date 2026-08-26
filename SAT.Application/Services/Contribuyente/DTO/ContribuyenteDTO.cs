using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAT.Application.Services.Contribuyente.DTO
{
    public class ContribuyenteDTO
    {
        public int IdUser { get; private set; }
        public string Nombre { get; private set; } = null!;
        public string ApellidoPaterno { get; private set; } = null!;
        public string ApellidoMaterno { get; private set; } = null!;
        public DateTime FechaNacimiento { get; private set; }
        public string? RFC { get; private set; }
    }
}
