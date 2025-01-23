using System.ComponentModel.DataAnnotations;

namespace Webhooks.Models
{
    public class WeatherData
    {
        [Key]
        public Guid Id { get; set; } = Guid.CreateVersion7();
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public int Temperature { get; set; }
        public int Humidity { get; set; }
    }

}
