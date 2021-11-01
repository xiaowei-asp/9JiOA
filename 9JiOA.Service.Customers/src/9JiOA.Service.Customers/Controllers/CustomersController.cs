using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _9JiOA.Service.Customers.Infrastructure.AggregateRoots;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace _9JiOA.Service.Customers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CustomersController> _logger;

        public CustomersController(ILogger<CustomersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public List<WeatherForecast> Add(WeatherForecast model)
        {
            model.Date = DateTime.Now;
            var list = new List<WeatherForecast>();
            list.Add(model);
            return list;
        }

        [HttpGet("get-user/{userId}")]
        public UserInfoDto GetUserInfo(string userId)
        {
            var userDto = new UserInfoDto();

            if (userId == "124" || userId == "123")
            {
                userDto.Id = userId;
                userDto.UserName = "identity-user";
                userDto.NickName = "identity";
                userDto.Address = "identity/get-user";
                userDto.IsVip = false;
            }
            return userDto;
        }
    }
}
