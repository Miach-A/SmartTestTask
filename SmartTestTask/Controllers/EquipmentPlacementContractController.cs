using Microsoft.AspNetCore.Mvc;

namespace SmartTestTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EquipmentPlacementContractController : ControllerBase
    {

        private readonly ILogger<EquipmentPlacementContractController> _logger;

        public EquipmentPlacementContractController(
            ILogger<EquipmentPlacementContractController> logger
            )
        {
            _logger = logger;
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpPost]
        public async Task<IActionResult> PostContract()
        {

            return Ok();//new EquipmentPlacementContract().Ma
        }
    }
}