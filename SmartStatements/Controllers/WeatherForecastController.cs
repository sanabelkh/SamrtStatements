using Microsoft.AspNetCore.Mvc;
using SmartStatements.Core.Statements.Commands;
using MediatR;
using SmartStatements.Infra;

namespace SmartStatements.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {


        //private readonly IMediator  _mediator;

        public WeatherForecastController(IMediator mediator)
        {
            //_mediator = mediator;
        }

        //[HttpPost("generate")]
        //public async Task<IActionResult> Generate(GenerateStatementCommand command)
        //{
        //    var statementId = await _mediator.Send(command);
        //    return Ok(statementId);
        //}


        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
