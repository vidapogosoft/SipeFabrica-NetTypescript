using System;
using System.Collections.Generic;

namespace Model.Entidades.Database;

public partial class ConfigurationProfile
{
    public int IdConfiguration { get; set; }

    public string? NameProfile { get; set; }

    public string? StatusProfile { get; set; }

    public DateTime? DateRecord { get; set; }
}
