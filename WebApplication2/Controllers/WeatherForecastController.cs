using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ISsrfService _ssrfService;

        public WeatherForecastController(ISsrfService ssrfService)
        {
            _ssrfService = ssrfService;
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

        /// <summary>
        /// todos/1
        /// </summary>
        /// <param name="domain">1</param>
        /// <returns></returns>
        [HttpGet(Name = "GetDomain")]
        public async Task<string> GetDomainAsync(string domain)
        {
            return await _ssrfService.SsrfTokenAsync(domain);


            //const string contosoUrl = "http://www.contoso.com/";
            //const string googleUrl = "http://www.google.com/";

            //var response = await client.GetAsync(contosoUrl);


            //return url.AbsolutePath;
        }
    }
}
