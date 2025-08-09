using BackendTaller.Models.DTO;
using Microsoft.EntityFrameworkCore;
using ModelTaller.Entidades.Database;
using ModelTaller.Entidades.DTO;

namespace BackendTaller.DA
{
    public class DROrders
    {

        public List<OrderPedido> ConsultaOrder()
        {
            using (var ctx = new HandHeldContext())
            {
                return ctx.OrderPedidos.Where(a => a.Estado == "ACTIVO").Take(20).ToList();
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


        public List<DTOOrders> ConsultaOrdenes(int IdOrder)
        {
            using (var ctx = new HandHeldContext())
            {
                var x = (
                            from a in ctx.OrderPedidos
                            join b in ctx.OrderPedidoDetalles on a.IdOrderCab equals b.IdOrderCab
                            where a.Estado == "ACTIVO"
                            && a.IdOrderCab == IdOrder
                            select new DTOOrders
                            {
                                IdOrderCab = a.IdOrderCab,
                                CodTienda = a.CodTienda,
                                Tienda = a.Tienda,
                                FechaIngreso = a.FechaIngreso,
                                IdDispo = b.IdDispo,
                                NombreDispo = b.NombreDispo,
                                CodItem = b.CodItem,
                                DescripcionItem = b.DescripcionItem,
                                Cantidad = b.Cantidad

                            }).OrderByDescending(a=> a.CodItem).ToList();

                return x;
            }
        }

        public List<DTOPedidoDetalle> ConsultaOrdenesDetalle(int IdOrder)
        {
            using (var ctx = new HandHeldContext())
            {

                return ctx.PedidoDetalle.FromSqlRaw("ConsPedidoDetalle {0}", IdOrder).ToList();

            }
        }

        public List<DTOPedidoDetalle> ConsultaOrdenesDetallev2(DTOOrders order)
        {
            using (var ctx = new HandHeldContext())
            {

                return ctx.PedidoDetalle.FromSqlRaw("ConsPedidoDetalle {0}", order.IdOrderCab).ToList();

            }
        }
    }
}
