namespace ModelTaller.Entidades.DTO
{
    public class DTOPedidoDetalle
    {

        public int IdOrderCab { get; set; }

        public int? IdDispo { get; set; }

        public string? NombreDispo { get; set; }

        public string? CodItem { get; set; }

        public string? DescripcionItem { get; set; }

        public int? Cantidad { get; set; }

    }
}
