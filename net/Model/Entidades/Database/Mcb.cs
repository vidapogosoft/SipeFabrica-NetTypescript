using System;
using System.Collections.Generic;

namespace Model.Entidades.Database;

public partial class Mcb
{
    public string Email { get; set; } = null!;

    public string? Contacto { get; set; }

    public string? Telefono { get; set; }

    public string? Fechaactualizacion { get; set; }

    public string? Asunto1 { get; set; }

    public string? Asunto2 { get; set; }

    public string? Cuerpomensaje1 { get; set; }

    public string? Cuerpomensaje2 { get; set; }

    public string? Smtp { get; set; }

    public string? Idioma { get; set; }

    public string? Asunto3 { get; set; }

    public string? Cuerpomensaje3 { get; set; }
}
