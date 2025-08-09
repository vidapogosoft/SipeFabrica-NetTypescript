using ModelTaller.Entidades.Database;

namespace BackendTaller.DA
{
    public class DWOrders
    {

        public int RegistroOrder (OrderPedido item)
        {
            using (var ctx = new HandHeldContext())
            {

                ctx.OrderPedidos.Add(item);
                ctx.SaveChanges();

                return item.IdOrderCab;
            }
        }

        public int RegistroOrderDetalle(OrderPedidoDetalle item)
        {
            using (var ctx = new HandHeldContext())
            {

                ctx.OrderPedidoDetalles.Add(item);
                ctx.SaveChanges();

                return item.IdOrderDet;
            }
        }

    }
}
