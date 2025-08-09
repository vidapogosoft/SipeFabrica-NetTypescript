using System;
using System.Collections.Generic;

namespace Model.Entidades.Database;

public partial class CatImagen
{
    public long IdImagen { get; set; }

    public byte[] Imagen { get; set; } = null!;

    public string NombreImagen { get; set; } = null!;
}
