using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAT.Application.Common
{
    public record Respuesta<T>
    {
        public bool Exito { get; init; } = true;
        public string Mensaje { get; init; } = string.Empty;
        public string? Error { get; init; }
        public IReadOnlyList<T>? Items { get; init; }
        public T? Item { get; init; }
        public int? Total { get; init; }
    }
}
