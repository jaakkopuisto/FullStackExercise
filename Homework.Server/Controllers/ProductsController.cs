using Homework.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Security.Cryptography.Xml;
using System.Text.Json;

namespace Homework.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly string _productsUrl;
        private readonly IConfiguration _configuration;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _productsUrl = configuration["Dummyjson:products"];
            _configuration = configuration;
        }

        [HttpGet(Name = "GetProducts")]
        public async Task<Root> Get()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(_configuration.GetValue<string>("Dummyjson:products")!);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync(_productsUrl).Result;

            using var contentStream = response.Content.ReadAsStreamAsync().Result;
            if(contentStream != null)
            {
                Root root = await System.Text.Json.JsonSerializer.DeserializeAsync<Root>(contentStream);

                return root;
            }
            else
            {
                return null;
            }
            
        }
    }
}
