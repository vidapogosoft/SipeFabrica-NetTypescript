using System;
using System.Collections.Generic;

namespace Model.Entidades.Database;

public partial class BitacoraUsuario
{
    public int IdBitacoraUsuario { get; set; }

    public string IdUsuario { get; set; } = null!;

    public DateTime FechaIngreso { get; set; }
}
