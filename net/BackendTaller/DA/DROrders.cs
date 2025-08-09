using ModelTaller.Entidades.Database;

namespace BackendTaller.DA
{
    public class DROrders
    {

        public List<OrderPedido> ConsultaOrder()
        {
            using (var ctx = new HandHeldContext())
            {
                return ctx.OrderPedidos.Where(a => a.Estado == "ACTIVO").OrderByDescending(a=> a.IdOrderCab).Take(20).ToList();
            }
        }

        public List<OrderPedido> ConsultaOrderByIdorder(int IdOrder)
        {
            using (var ctx = new HandHeldContext())
            {
                return ctx.OrderPedidos.Where(a => a.Estado == "ACTIVO" && a.IdOrderCab == IdOrder).ToList();
            }
        }

        public OrderPedido? ConsultaOrderObjectByIdorder(int IdOrder)
        {
            using (var ctx = new HandHeldContext())
            {
                return ctx.OrderPedidos.Where(a => a.Estado == "ACTIVO" && a.IdOrderCab == IdOrder).FirstOrDefault();
            }

        }

        public List<OrderPedidoDetalle> ConsultaOrderDetalleByIdorder(int IdOrder)
        {
            using (var ctx = new HandHeldContext())
            {
                return ctx.OrderPedidoDetalles.Where(a => a.Estado == "ACTIVO" && a.IdOrderCab == IdOrder).ToList();
            }
        }
    }
}
