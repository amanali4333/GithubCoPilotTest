using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using NUnit.Framework;

namespace GithubCoPilotTest.BusinessLogic
{
    public static class WeatherForecastBL
    {
        //Add a list that will hold the weather forecast
        private static List<WeatherForecast> weatherForecastList = new();

        //Add a method to return the list of weather forecast
        public static IEnumerable<WeatherForecast> GetWeatherForecast()
        {
            return weatherForecastList;
        }


        // Add a method to add a weather forecast to the list
        public static void Add(WeatherForecast weatherForecast)
        {
            weatherForecastList.Add(weatherForecast);
        }

        //write test for above method
        [Test]
        public static void AddWeatherForecastTest()
        {
            //Arrange
            var weatherForecast = new WeatherForecast
            {
                City = "London",
                Country = new Country { Name = "UK" },
                Date = DateTime.Now,
                Summary = "Hot",
                TemperatureC = 30
            };

            //Act
            Add(weatherForecast);

            //Assert
            Assert.AreEqual(weatherForecastList.Count, 1);
        }


        //add a method to return the weather forecast list ordered by date
        public static IEnumerable<WeatherForecast> GetWeatherForecastOrderedByDate()
        {
            return weatherForecastList.OrderBy(x => x.Date);
        }
        //write test for above method
        [Test]
        public static void GetWeatherForecastOrderedByDateTest()
        {
            //Arrange
            var weatherForecast = new WeatherForecast
            {
                City = "London",
                Country = new Country { Name = "UK" },
                Date = DateTime.Now,
                Summary = "Hot",
                TemperatureC = 30
            };
            Add(weatherForecast);

            //Act
            var result = GetWeatherForecastOrderedByDate();

            //Assert
            Assert.AreEqual(result.FirstOrDefault().City, "London");
        }


        //add a method to return the weather forecast list ordered by temperature
        public static IEnumerable<WeatherForecast> GetWeatherForecastOrderedByTemperature()
        {
            return weatherForecastList.OrderBy(x => x.TemperatureC);
        }
        //write test for above method
        [Test]
        public static void GetWeatherForecastOrderedByTemperatureTest()
        {
            //Arrange
            var weatherForecast = new WeatherForecast
            {
                City = "London",
                Country = new Country { Name = "UK" },
                Date = DateTime.Now,
                Summary = "Hot",
                TemperatureC = 30
            };
            Add(weatherForecast);

            //Act
            var result = GetWeatherForecastOrderedByTemperature();

            //Assert
            Assert.AreEqual(result.FirstOrDefault().City, "London");
        }


        // add a method that takes the city name and returns the weather forecast for that city
        public static IEnumerable<WeatherForecast> GetWeatherForecastByCity(string city)
        {
            return weatherForecastList.Where(x => x.City == city);
        }
        //write test for above method
        [Test]
        public static void GetWeatherForecastByCityTest()
        {
            //Arrange
            var weatherForecast = new WeatherForecast
            {
                City = "London",
                Country = new Country { Name = "UK" },
                Date = DateTime.Now,
                Summary = "Hot",
                TemperatureC = 30
            };
            Add(weatherForecast);

            //Act
            var result = GetWeatherForecastByCity("London");

            //Assert
            Assert.AreEqual(result.FirstOrDefault().City, "London");
        }


        // add a method that can take either country or city and return forecast against that
        public static IEnumerable<WeatherForecast> GetWeatherForecastByCountryOrCity(string country, string city)
        {
            return weatherForecastList.Where(x => x.City == city || x.Country.Name == country);
        }
        //write test for above method
        [Test]
        public static void GetWeatherForecastByCountryOrCityTest()
        {
            //Arrange
            var weatherForecast = new WeatherForecast
            {
                City = "London",
                Country = new Country { Name = "UK" },
                Date = DateTime.Now,
                Summary = "Hot",
                TemperatureC = 30
            };
            Add(weatherForecast);

            //Act
            var result = GetWeatherForecastByCountryOrCity("UK", "London");

            //Assert
            Assert.AreEqual(result.FirstOrDefault().City, "London");
        }
        //write test for above method
        [Test]
        public static void GetWeatherForecastByCountryOrCityTest2()
        {
            //Arrange
            var weatherForecast = new WeatherForecast
            {
                City = "London",
                Country = new Country { Name = "UK" },
                Date = DateTime.Now,
                Summary = "Hot",
                TemperatureC = 30
            };
            Add(weatherForecast);

            //Act
            var result = GetWeatherForecastByCountryOrCity("UK", "London");

            //Assert
            Assert.AreEqual(result.FirstOrDefault().Country.Name, "UK");
        }

        // add a method that return the data in groups of countries against the forecast of the city of that country
        // then it returns the group of countries with the highest temperature and the cities are sorted by temperature in descending order
        public static IEnumerable<WeatherForecast> GetWeatherForecastByCountryGrouped()
        {
            return weatherForecastList.GroupBy(x => x.Country).Select(x => new WeatherForecast
            {
                Country = x.Key,
                City = x.OrderByDescending(y => y.TemperatureC).FirstOrDefault().City,
                TemperatureC = x.OrderByDescending(y => y.TemperatureC).FirstOrDefault().TemperatureC
            }).OrderByDescending(x => x.TemperatureC);
        }
        //write test for above method
        [Test]
        public static void GetWeatherForecastByCountryGroupedTest()
        {
            //Arrange
            var weatherForecast = new WeatherForecast
            {
                City = "London",
                Country = new Country { Name = "UK" },
                Date = DateTime.Now,
                Summary = "Hot",
                TemperatureC = 30
            };
            Add(weatherForecast);

            //Act
            var result = GetWeatherForecastByCountryGrouped();

            //Assert
            Assert.AreEqual(result.FirstOrDefault().Country.Name, "UK");
        }


        // add a method that returns the data in format of a country and the cities in that country with temperature in descending order
        public static IEnumerable<WeatherForecast> GetWeatherForecastByCountryGroupedWithCities()
        {
            return weatherForecastList.GroupBy(x => x.Country).Select(x => new WeatherForecast
            {
                Country = x.Key,
                City = string.Join(",", x.OrderByDescending(y => y.TemperatureC).Select(y => y.City)),
                TemperatureC = x.MaxBy(y => y.TemperatureC).TemperatureC
            }).OrderByDescending(x => x.TemperatureC);
        }
        //write test for above method
        [Test]
        public static void GetWeatherForecastByCountryGroupedWithCitiesTest()
        {
            //Arrange
            var weatherForecast = new WeatherForecast
            {
                City = "London",
                Country = new Country { Name = "UK" },
                Date = DateTime.Now,
                Summary = "Hot",
                TemperatureC = 30
            };
            Add(weatherForecast);

            //Act
            var result = GetWeatherForecastByCountryGroupedWithCities();

            //Assert
            Assert.AreEqual(result.FirstOrDefault().Country.Name, "UK");
        }


        //add a method to return the forecast of any random city every time
        public static WeatherForecast GetWeatherForecastByRandomCity()
        {
            return weatherForecastList.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
        }
        //write test for above method
        [Test]
        public static void GetWeatherForecastByRandomCityTest()
        {
            //Arrange
            var weatherForecast = new WeatherForecast
            {
                City = "London",
                Country = new Country { Name = "UK" },
                Date = DateTime.Now,
                Summary = "Hot",
                TemperatureC = 30
            };
            Add(weatherForecast);

            //Act
            var result = GetWeatherForecastByRandomCity();

            //Assert
            Assert.AreEqual(result.City, "London");
        }
    }
}
