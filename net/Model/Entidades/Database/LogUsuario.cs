using System;
using System.Collections.Generic;

namespace Model.Entidades.Database;

public partial class LogUsuario
{
    public int Id { get; set; }

    public string? IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Departamento { get; set; }

    public string? Email { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? IdUsuarioCreacion { get; set; }

    public string? IdUsuarioModifico { get; set; }

    public DateTime? FechaModifico { get; set; }

    public string? Tipo { get; set; }
}
