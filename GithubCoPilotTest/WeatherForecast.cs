namespace GithubCoPilotTest
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }

        // add city, country properties in this class
        public string? City { get; set; }

        public Country Country { get; set; }
    }

    // Add a class for country and also include properties that can impact weather of that country
    public class Country
    {
        public string? Name { get; set; }
        public string? Capital { get; set; }
        public string? Currency { get; set; }
        public string? Language { get; set; }
        public string? Continent { get; set; }
        public string? Population { get; set; }
    }
}