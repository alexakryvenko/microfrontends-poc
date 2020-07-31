using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MicroserviceApi1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Implementing your API Gateways with Ocelot",
            "Service discovery in the client side integrating Ocelot with Consul or Eureka",
            "Caching at the API Gateway tier",
            "Logging at the API Gateway tier",
            "Quality of Service (Retries and Circuit breakers) at the API Gateway tier"
        };

        private readonly ILogger<NewsController> _logger;

        public NewsController(ILogger<NewsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<NewsItem> Get()
        {
            var rng = new Random();
            return Summaries.Select((i, index) => new NewsItem
            {
                Date = DateTime.Now.AddDays(index),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
