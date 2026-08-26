using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SAT.Infrastructure.Persistence.Entities;

[Table("RFC")]
public partial class Rfc
{
    [Key]
    public int IdUser { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string ApellidoPaterno { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? ApellidoMaterno { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaNacimiento { get; set; }

    [Column("RFC")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Rfc1 { get; set; }
}
