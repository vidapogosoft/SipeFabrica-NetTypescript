using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using BackendTaller.Interfaces;
using ModelTaller.Entidades.Database;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.AspNetCore.Authorization;

namespace BackendTaller.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly IOrder iorders;

        public OrdersController(IOrder orders)
        {
            iorders = orders;
        }

        [HttpGet("home")]
        public IActionResult ConsultaOrder()
        {
            return Ok(iorders.ConsultaOrder());
        }

        [HttpGet("order/{IdOrder}")]
        public IActionResult ConsultaOrderByIdorder(int IdOrder)
        {
            return Ok(iorders.ConsultaOrderByIdorder(IdOrder));
        }

        [HttpGet("detalles/{IdOrder}")]
        public IActionResult ConsultaOrderDetalleByIdorder(int IdOrder)
        {
            return Ok(iorders.ConsultaOrderDetalleByIdorder(IdOrder));
        }

        [HttpGet("orderobject/{IdOrder}")]
        public IActionResult ConsultaOrderObjectByIdorder(int IdOrder)
        {
            return Ok(iorders.ConsultaOrderDetalleByIdorder(IdOrder));
        }

        //[HttpGet("orderobjectv2")]
        //public IActionResult ConsultaOrderObjectByIdorderv2([FromBody] OrderPedidoDetalle item)
        //{
        //    int? param = item.IdOrderCab;
        //    return Ok(iorders.ConsultaOrderDetalleByIdorder(param));
        //}

        [HttpPost("registro")]
        public IActionResult RegistroDatos([FromBody] OrderPedido item)
        {
            try
            {
                int Caborder = 0;
                int CaborderDet = 0;

                if (item == null)
                {
                    return BadRequest("Error en registro de datos: Objeto null");
                }

                Caborder = iorders.RegistroDatos(item);

                if(Caborder > 0)
                {
                    List<OrderPedidoDetalle>? OrdenDetalle 
                        = JsonConvert.DeserializeObject<List<OrderPedidoDetalle>>(item.JsonOrder);

                    if(OrdenDetalle.Count > 0)
                    {
                        for (int od=0; od < OrdenDetalle.Count; od++ )
                        {
                            var detalle = new OrderPedidoDetalle
                            {
                                IdOrderCab = Caborder,
                                DescripcionItem = OrdenDetalle[od].DescripcionItem,
                                CodItem = OrdenDetalle[od].CodItem,
                                Cantidad = OrdenDetalle[od].Cantidad,
                                CodTienda = OrdenDetalle[od].CodTienda
                            };

                            CaborderDet = iorders.RegistroDetalle(detalle);

                        }

                    }

                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


            return Ok(item.IdOrderCab);

        }

        [AllowAnonymous]
        [HttpGet("ordenes/{IdOrder}")]
        public IActionResult ConsultaOrdenes(int IdOrder)
        {
            return Ok(iorders.ConsultaOrdenes(IdOrder));
        }

        [AllowAnonymous]
        [HttpGet("ordenesv2/{IdOrder}")]
        public IActionResult ConsultaOrdenesDetalle(int IdOrder)
        {
            return Ok(iorders.ConsultaOrdenesDetalle(IdOrder));
        }


        // GET: api/<OrdersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrdersController>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
