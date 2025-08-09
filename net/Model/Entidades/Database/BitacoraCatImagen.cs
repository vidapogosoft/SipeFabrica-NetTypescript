using System;
using System.Collections.Generic;

namespace Model.Entidades.Database;

public partial class BitacoraCatImagen
{
    public long IdBitacora { get; set; }

    public long IdImagen { get; set; }

    public byte[] Imagen { get; set; } = null!;

    public string NombreImagen { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }
}
