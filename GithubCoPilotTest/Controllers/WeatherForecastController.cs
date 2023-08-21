using GithubCoPilotTest.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Xunit;

namespace GithubCoPilotTest.Controllers
{
    [ApiController]
    [Route("[controller]")]

    // add a controller class that use the business logic of WeatherForecastBL class 
    public class WeatherForecastController : ControllerBase
    {
        // add a constructor that will inject the logger
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        // add a method that will return a list of weather forecast
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> GetWeatherForecast()
        {
            return WeatherForecastBL.GetWeatherForecast();
        }

        // add a method that will add a weather forecast
        [HttpPost(Name = "AddWeatherForecast")]
        public void AddWeatherForecast(WeatherForecast weatherForecast)
        {
            WeatherForecastBL.Add(weatherForecast);
        }

        // add a method that will return a list of weather forecast ordered by date
        [HttpGet(Name = "GetWeatherForecastOrderedByDate")]
        public IEnumerable<WeatherForecast> GetWeatherForecastOrderedByDate()
        {
            return WeatherForecastBL.GetWeatherForecastOrderedByDate();
        }

        // add a method that will return a list of weather forecast ordered by temperature
        [HttpGet(Name = "GetWeatherForecastOrderedByTemperature")]
        public IEnumerable<WeatherForecast> GetWeatherForecastOrderedByTemperature()
        {
            return WeatherForecastBL.GetWeatherForecastOrderedByDate();
        }

        // add a method that will return a list of weather forecast by city
        [HttpGet(Name = "GetWeatherForecastByCity")]
        public IEnumerable<WeatherForecast> GetWeatherForecastByCity(string city)
        {
            return WeatherForecastBL.GetWeatherForecastByCity(city);
        }

        // add a method that will return a list of weather forecast by country or city
        [HttpGet(Name = "GetWeatherForecastByCountryOrCity")]
        public IEnumerable<WeatherForecast> GetWeatherForecastByCountryOrCity(string country, string city)
        {
            return WeatherForecastBL.GetWeatherForecastByCountryOrCity(country, city);
        }

        // add a method that will return a list of weather forecast by country grouped
        [HttpGet(Name = "GetWeatherForecastByCountryGrouped")]
        public IEnumerable<WeatherForecast> GetWeatherForecastByCountryGrouped()
        {
            return WeatherForecastBL.GetWeatherForecastByCountryGrouped();
        }

        // add a method that will return a list of weather forecast by country grouped with cities
        [HttpGet(Name = "GetWeatherForecastByCountryGroupedWithCities")]
        public IEnumerable<WeatherForecast> GetWeatherForecastByCountryGroupedWithCities()
        {
            return WeatherForecastBL.GetWeatherForecastByCountryGroupedWithCities();
        }

        // add a method that will return the forecast of any random city
        [HttpGet(Name = "GetWeatherForecastByRandomCity")]
        public WeatherForecast GetWeatherForecastByRandomCity()
        {
            return WeatherForecastBL.GetWeatherForecastByRandomCity();
        }

        // add unit test for all methods
        [Test]
        public void GetWeatherForecastTest()
        {
            // Arrange
            var controller = new WeatherForecastController(_logger);

            // Act
            var result = controller.GetWeatherForecast();

            // Assert
            Assert.NotNull(result);
        }

        [Test]
        public void AddWeatherForecastTest()
        {
            // Arrange
            var controller = new WeatherForecastController(_logger);
            var weatherForecast = new WeatherForecast
            {
                Date = DateTime.Now.AddDays(1),
                TemperatureC = 20,
                Summary = "Warm",
                City = "Karachi",
                Country = new Country
                {
                    Name = "Pakistan",
                    Capital = "Islamabad",
                    Currency = "Pakistani Rupee",
                    Language = "Urdu",
                    Continent = "Asia",
                    Population = "220892340"
                }
            };

            // Act
            controller.AddWeatherForecast(weatherForecast);

            // Assert
            Assert.NotNull(controller.GetWeatherForecastOrderedByDate().FirstOrDefault(x => x.City == "Karachi"));
        }

        [Test]
        public void GetWeatherForecastOrderedByDateTest()
        {
            // Arrange
            var controller = new WeatherForecastController(_logger);

            // Act
            var result = controller.GetWeatherForecastOrderedByDate();

            // Assert
            Assert.NotNull(result);
        }

        [Test]
        public void GetWeatherForecastOrderedByTemperatureTest()
        {
            // Arrange
            var controller = new WeatherForecastController(_logger);

            // Act
            var result = controller.GetWeatherForecastOrderedByTemperature();

            // Assert
            Assert.NotNull(result);
        }

        [Test]
        public void GetWeatherForecastByCityTest()
        {
            // Arrange
            var controller = new WeatherForecastController(_logger);

            // Act
            var result = controller.GetWeatherForecastByCity("Karachi");

            // Assert
            Assert.NotNull(result);
        }

        [Test]
        public void GetWeatherForecastByCountryOrCityTest()
        {
            // Arrange
            var controller = new WeatherForecastController(_logger);

            // Act
            var result = controller.GetWeatherForecastByCountryOrCity("Pakistan", "Karachi");

            // Assert
            Assert.NotNull(result);
        }

        [Test]
        public void GetWeatherForecastByCountryGroupedTest()
        {
            // Arrange
            var controller = new WeatherForecastController(_logger);

            // Act
            var result = controller.GetWeatherForecastByCountryGrouped();

            // Assert
            Assert.NotNull(result);
        }

        [Test]
        public void GetWeatherForecastByCountryGroupedWithCitiesTest()
        {
            // Arrange
            var controller = new WeatherForecastController(_logger);

            // Act
            var result = controller.GetWeatherForecastByCountryGroupedWithCities();

            // Assert
            Assert.NotNull(result);
        }
    }
}