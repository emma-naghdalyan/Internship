using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace EntityFramework_DesignTables.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly List<string> Summaries = new List<string>()
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Summaries.ToArray();
        }

        [HttpGet("{name}")]
        //[Route("{name}")]
        public string GetByName([FromRoute]string name)
        {
            return Summaries.FirstOrDefault(w => w == name);
        }

        [HttpDelete("{name}")]
        public void Delete([FromRoute] string name)
        {
            Summaries.Remove(name);
        }
    }
}
