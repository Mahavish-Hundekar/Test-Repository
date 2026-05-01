<<<<<<< HEAD
namespace MyApi
=======
namespace GroceryApi
>>>>>>> 0ef7ab7f4ef1003900307c2bd54c6c0e7e18ca62
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}
