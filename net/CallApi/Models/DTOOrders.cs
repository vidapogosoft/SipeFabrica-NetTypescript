
namespace CallApi.Models
{
    public class DTOOrders
    {
        public int IdOrderCab { get; set; }

        public int? IdOrderDispo { get; set; }

        public string? CodTienda { get; set; }

        public string? Tienda { get; set; }

        public string? Enviado { get; set; }

        public string? Observacion { get; set; }

        public string? UsuarioIngreso { get; set; }

        public DateTime? FechaIngreso { get; set; }

        public string? JsonOrder { get; set; }
    }
}
