using System;
using System.Collections.Generic;

namespace Model.Entidades.Database;

public partial class CatParametro
{
    public long IdCat { get; set; }

    public string Parametro { get; set; } = null!;

    public string Valor { get; set; } = null!;
}
