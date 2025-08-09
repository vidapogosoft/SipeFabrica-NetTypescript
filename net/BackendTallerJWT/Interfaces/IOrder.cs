using BackendTaller.Models.DTO;
using ModelTaller.Entidades.Database;
using ModelTaller.Entidades.DTO;

namespace BackendTaller.Interfaces
{
    public interface IOrder
    {

        IEnumerable<OrderPedido> ConsultaOrder();
        IEnumerable<OrderPedido> ConsultaOrderByIdorder(int IdOrder);
        OrderPedido? ConsultaOrderObjectByIdorder(int IdOrder);
        IEnumerable<OrderPedidoDetalle> ConsultaOrderDetalleByIdorder(int IdOrder);
        int RegistroDatos(OrderPedido item);
        int RegistroDetalle(OrderPedidoDetalle item);

        IEnumerable<DTOOrders> ConsultaOrdenes(int IdOrder);
        IEnumerable<DTOPedidoDetalle> ConsultaOrdenesDetalle(int IdOrder);
    }
}
