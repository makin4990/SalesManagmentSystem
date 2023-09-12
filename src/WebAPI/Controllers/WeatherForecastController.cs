using Infrastructure.Services.Slack;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SlackAPI;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes ="Admin")]
    public class WeatherForecastController : BaseController
    {
        private readonly ISlackService _slackService;
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ISlackService slackService)
        {
            _logger = logger;
            _slackService = slackService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var result = _slackService.SendMessagce("general", "Selamun Aleykum").Result;
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("SendMessage")]

        public async Task<PostMessageResponse> SendMessage(string message)
        {
            var result = await _slackService.SendMessagce("general", message);
            return result;
        }
    }
}