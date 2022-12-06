
namespace TaxiGoAPI.DBO
{
    public class RequestModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int PassengerCount { get; set; }

        public string Location { get; set; }

        public int? TaxiId { get; set; }
    }
}
