namespace WeatherService.Models
{
    public class WeatherData
    {

        public Guid Id { get; set; } = Guid.CreateVersion7();
        public string Location { get; set; } = "Paris";
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public int Temperature { get; set; }
        public int Humidity { get; set; }
    }
}
