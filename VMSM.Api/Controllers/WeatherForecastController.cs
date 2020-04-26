using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VMSM.Contracts.Entities;
using VMSM.Contracts;
using VMSM.Contracts.Interfaces;

namespace VMSM.Api.Controllers
{
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> logger;
        private readonly IUserService _userService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IUserService userService)
        {
            this.logger = logger;
            this._userService = userService;
        }

        [HttpGet]
        [Route(Routes.Test.Root)]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();

            var user = _userService.GetUserById(4);

            var product = new Product { 
                PurchasePrice = 20,
                Tax = 5,
                Profit = 10,
                Rebate = 25
            };

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
