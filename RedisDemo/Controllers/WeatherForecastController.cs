using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;

namespace RedisDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IDistributedCache _cache;
        public WeatherForecastController(IDistributedCache cache)
        {
            this._cache = cache;
        }
        public string Index()
        {
            string test = _cache.GetString("Key-Test") ?? "";
            if (string.IsNullOrEmpty(test))
            {
                _cache.SetString($"Key-Test", $"Value-{DateTime.Now}");
                test = _cache.GetString("Key-Test") ?? "";
            }
            return test;
        }
    }
}
