using System;
using System.Collections.Generic;

namespace ModelTaller.Entidades.Database;

public partial class OrderPedidoDetalle
{
    public int IdOrderDet { get; set; }

    public int? IdOrderDetalle { get; set; }

    public int? IdOrderDispo { get; set; }

    public string? CodTienda { get; set; }

    public string? Tienda { get; set; }

    public int? IdDispo { get; set; }

    public string? NombreDispo { get; set; }

    public string? CodItem { get; set; }

    public string? DescripcionItem { get; set; }

    public int? Cantidad { get; set; }

    public string? Enviado { get; set; }

    public string? UsuarioIngreso { get; set; }

    public DateTime? FechaIngreso { get; set; }

    public string? FechaIngresoConsulta { get; set; }

    public DateTime? FechaSyncIngreso { get; set; }

    public string? FechaSyncIngresoConsulta { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public string? Estado { get; set; }

    public int? IdOrderCab { get; set; }
}
