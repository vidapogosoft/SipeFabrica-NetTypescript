namespace BackendTaller.Models.DTO
{
    public class DTOOrders
    {
        public int IdOrderCab { get; set; }

        public string? CodTienda { get; set; }

        public string? Tienda { get; set; }

        public string? Observacion { get; set; }

        public string? UsuarioIngreso { get; set; }

        public DateTime? FechaIngreso { get; set; }

        public int? IdDispo { get; set; }

        public string? NombreDispo { get; set; }

        public string? CodItem { get; set; }

        public string? DescripcionItem { get; set; }

        public int? Cantidad { get; set; }

        public string? Propiedad1 { get; set; }
        public string? Propiedad2 { get; set; }
        public string? Propiedad3 { get; set; }
        public string? Propiedad4 { get; set; }
        public string? Propiedad5 { get; set; }

    }
}
