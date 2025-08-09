using System;
using System.Collections.Generic;

namespace Model.Entidades.Database;

public partial class BitacoraFirmaAutorizada
{
    public long IdBitacora { get; set; }

    public long Secuencial { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Cargo { get; set; }

    public string? Firma { get; set; }

    public string? TipoFirma { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? IdColaborador { get; set; }

    public string? Comentarios { get; set; }
}
