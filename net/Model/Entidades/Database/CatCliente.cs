using System;
using System.Collections.Generic;

namespace Model.Entidades.Database;

public partial class CatCliente
{
    public string IdCliente { get; set; } = null!;

    public string? Nombre { get; set; }

    public byte[]? Foto { get; set; }
}
