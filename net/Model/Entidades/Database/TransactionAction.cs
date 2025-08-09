using System;
using System.Collections.Generic;

namespace Model.Entidades.Database;

public partial class TransactionAction
{
    public int IdTran { get; set; }

    public string? KeyTran { get; set; }

    public string? ActionTran { get; set; }

    public string? TableTran { get; set; }

    public string? Value1Tran { get; set; }

    public string? Value2Tran { get; set; }

    public string? Value3Tran { get; set; }

    public string? MessagesTran { get; set; }

    public DateTime? DateRecord { get; set; }

    public string? Enviado { get; set; }
}
