using System.ComponentModel.DataAnnotations;

namespace TaxiGoAPI.Models
{
    public class Taxi
    {
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        public int CarLicense { get; set; }

        public int? DriverId { get; set; }

        public Driver? Driver { get; set; }

        public Request? Request { get; set; }
    }
}
