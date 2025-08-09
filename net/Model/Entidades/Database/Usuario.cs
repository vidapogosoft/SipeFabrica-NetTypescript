using System;
using System.Collections.Generic;

namespace Model.Entidades.Database;

public partial class Usuario
{
    public string IdUsuario { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string? Departamento { get; set; }

    public string Email { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string IdUsuarioCreacion { get; set; } = null!;

    public string? IdUsuarioModifico { get; set; }

    public DateTime? FechaModifico { get; set; }

    public string Tipo { get; set; } = null!;
}
