using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAT.Application.Services.Contribuyente.DTO
{
    public class ContribuyenteDTO
    {
        public int IdUser { get; set; }
        public string Nombre { get; set; } = null!;
        public string ApellidoPaterno { get; set; } = null!;
        public string ApellidoMaterno { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string ViewFechaNacimiento => FechaNacimiento.ToString("dd/MM/yyyy");
        public string? RFC { get; set; }
    }
}
