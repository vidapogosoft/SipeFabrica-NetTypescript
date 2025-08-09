using System;
using System.Collections.Generic;

namespace Model.Entidades.Database;

public partial class BitacoraSolicitudFirma
{
    public long IdBitacora { get; set; }

    public DateTime? FechaSolicitud { get; set; }

    public string? IdUsuarioSolicitante { get; set; }

    public string? IdUsuarioAprobador { get; set; }

    public string? IdFirma { get; set; }

    public string? Accion { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaAprobacion { get; set; }

    public string? Comentario { get; set; }

    public long? IdFirmaAntes { get; set; }

    public long? IdFirmaDespues { get; set; }
}
