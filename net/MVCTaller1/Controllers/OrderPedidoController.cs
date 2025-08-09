using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MVCTaller1.Models;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace MVCTaller1.Controllers
{
    public class OrderPedidoController : Controller
    {
        string BaseURL = "http://localhost:47903/";

        // GET: OrderPedidoController
        public async Task<ActionResult> Index()
        {
            //defino la lista
            var ListOrders = new List<OrderPedido>();

            //llenar lista
            using ( var client = new HttpClient())
            {
                //call api backend
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/Orders/home");

                if(res.IsSuccessStatusCode)
                {
                    var Response = res.Content.ReadAsStringAsync().Result;

                    ListOrders = JsonConvert.DeserializeObject<List<OrderPedido>>(Response);
                }

            }

           return View(ListOrders);
        }

        // GET: OrderPedidoController/Details/5
        public async Task<ActionResult> Details(int IdOrderCab)
        {

            //defino el objeto
            var Orders = new OrderPedido();

            //llenar lista
            using (var client = new HttpClient())
            {
                //call api backend
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/Orders/orderobject/" + IdOrderCab);

                if (res.IsSuccessStatusCode)
                {
                    var Response = res.Content.ReadAsStringAsync().Result;

                    Orders = JsonConvert.DeserializeObject<OrderPedido>(Response);
                }

            }

            return View(Orders);
        }

        // GET: OrderPedidoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderPedidoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderPedido item)
        {
            try
            {

                item.FechaIngreso = DateTime.Now;
                item.UsuarioIngreso = "FRONT";

                using (var client = new HttpClient())
                {

                    //call api backend
                    client.BaseAddress = new Uri(BaseURL);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var json = JsonConvert.SerializeObject(item);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage res = client.PostAsync("api/Orders/registro/", content).GetAwaiter().GetResult();

                    if(res.IsSuccessStatusCode)
                    {
                        var response = res.Content.ReadAsStringAsync().Result;
                    }

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderPedidoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderPedidoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderPedidoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderPedidoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
