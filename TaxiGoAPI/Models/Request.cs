

namespace TaxiGoAPI.Models
{
    public class Request
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int PassengerCount { get; set; }

        public string Location { get; set; }

        public int? TaxiId { get; set; }

        public ApplicationUser User { get; set; }

        public Taxi? Taxi { get; set; }
    }
}
