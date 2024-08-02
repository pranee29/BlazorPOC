using BlazorApp1_for_js.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1_for_js.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        //    private static readonly string[] Summaries = new[]
        //    {
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //    private readonly ILogger<WeatherForecastController> _logger;

        //    public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //    {
        //        _logger = logger;
        //    }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = 15,
        //        Summary = "Hello"
        //    })
        //    .ToArray();
        //}



        [HttpGet]
        public string Get()
        {

            //var files=System.IO.File
            var fileBytes = System.IO.File.ReadAllText("Hello.js");
            // return File(fileBytes, "application/javascript", "file.js");
            return fileBytes;
            //return File("JavaScript_hello.js", "application/javascript", "JavaScript_hello.js");
        }
    }
}