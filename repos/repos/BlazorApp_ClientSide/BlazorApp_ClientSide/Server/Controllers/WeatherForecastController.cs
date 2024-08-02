using BlazorApp_ClientSide.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp_ClientSide.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public  IEnumerable<WeatherForecast> Get()
        {
            JsonResult a; 
            return  Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = 15,
                Summary = "Hello"
            })
            .ToArray();
            //return result
        }



    }
}