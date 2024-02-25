﻿using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Homework.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly string _productsUrl = "";

        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _productsUrl = configuration["Dummyjson:products"] ?? "/errorPageUrl";
        }

        [HttpGet]
        public async Task<RootProducts> Get()
        {
            try
            {
                using var client = new HttpClient();
                client.BaseAddress = new Uri(_productsUrl);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                using (var response = await client.GetAsync(_productsUrl))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized) // Example for specific error handling
                    {
                        return new RootProducts(); // Would be best to show error page / message
                    }
                    else
                    {
                        response.EnsureSuccessStatusCode();

                        var contentStream = response.Content.ReadAsStreamAsync().Result;

                        return JsonSerializer.Deserialize<RootProducts>(contentStream) ?? new RootProducts();
                    }
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Caught exception:");
                System.Diagnostics.Debug.WriteLine(ex.Message);
                _logger.LogTrace(ex, ex.Message);
                return new RootProducts(); // Would be best to show error page / message
            }
        }
    }
}
