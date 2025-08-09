using BackendTaller.Interfaces;
using ModelTaller.Entidades.Database;
using BackendTaller.DA;

namespace BackendTaller.Services
{
    public class SOrders : IOrder
    {
        public DROrders data = new DROrders();
        public DWOrders dataR = new DWOrders();

        public IEnumerable<OrderPedido> ConsultaOrder()
        {
            return data.ConsultaOrder();
        }

        public IEnumerable<OrderPedido> ConsultaOrderByIdorder(int IdOrder)
        {
            return data.ConsultaOrderByIdorder(IdOrder);
        }

        public IEnumerable<OrderPedidoDetalle> ConsultaOrderDetalleByIdorder(int IdOrder)
        {
            return data.ConsultaOrderDetalleByIdorder(IdOrder);
        }

        public OrderPedido? ConsultaOrderObjectByIdorder(int IdOrder)
        {
            return data.ConsultaOrderObjectByIdorder(IdOrder);
        }

        public int RegistroDatos(OrderPedido item)
        {
            return dataR.RegistroOrder(item);
        }

        public int RegistroDetalle(OrderPedidoDetalle item)
        {
            return dataR.RegistroOrderDetalle(item);
        }

    }
}
