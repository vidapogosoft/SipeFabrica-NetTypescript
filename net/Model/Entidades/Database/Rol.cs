using System;
using System.Collections.Generic;

namespace Model.Entidades.Database;

public partial class Rol
{
    public int CodigoRol { get; set; }

    public string Descripcion { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public string IdUsuarioModifico { get; set; } = null!;
}
