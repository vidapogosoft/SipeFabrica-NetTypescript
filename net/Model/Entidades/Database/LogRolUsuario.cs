using System;
using System.Collections.Generic;

namespace Model.Entidades.Database;

public partial class LogRolUsuario
{
    public int Id { get; set; }

    public int? IdRol { get; set; }

    public string? IdUsuario { get; set; }

    public string? IdUsuarioAsigna { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Accion { get; set; }
}
