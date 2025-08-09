using CallApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace CallApi
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        public Task<string> tokenauth = null;
        public List<DTOOrders>? orders;

        HttpClient _Cliente;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            _Cliente = new HttpClient();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker 1 running at: {time}", DateTimeOffset.Now);


                    tokenauth = TokenAuth();

                    if(tokenauth != null)
                    {
                        Console.WriteLine(tokenauth);

                        GetOrders();
                    }


                }

                await Task.Delay(10000, stoppingToken);
            }
        }

        public async void GetOrders()
        {

            var uriget = new Uri("http://localhost:52958/api/Orders/ordenes");
            _Cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenauth.Result);
            var response = await _Cliente.GetAsync(uriget);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                orders = JsonConvert.DeserializeObject<List<DTOOrders>>(content);

                Console.WriteLine(orders.Count);

            }

        }

        public async Task<string> TokenAuth()
        {
            string token = string.Empty;

            var login = new DTOAuth
            {
                username = "admin",
                password = "123456"
            };

            var json = JsonConvert.SerializeObject(login);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;

            var urgettoken = new Uri("http://localhost:52958/api/Token/authenticate");

            response = await _Cliente.PostAsync(urgettoken, content);


            if(response.IsSuccessStatusCode)
            {
                token = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                Console.WriteLine(token);
            }
            else
            {
                Console.WriteLine("Error");
            }


            return token;

        }

    }
}
