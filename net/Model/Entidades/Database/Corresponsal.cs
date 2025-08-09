using System;
using System.Collections.Generic;

namespace Model.Entidades.Database;

public partial class Corresponsal
{
    public string? Banco { get; set; }

    public string? Contacto { get; set; }

    public string? User { get; set; }

    public string? Pass { get; set; }

    public string? Passanterior { get; set; }

    public string? Email { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? Intentos { get; set; }

    public DateTime? IntentosTimeStamp { get; set; }

    public int? OtpActivate { get; set; }

    public string? OtpSecret { get; set; }

    public int IdCorresponsal { get; set; }
}
