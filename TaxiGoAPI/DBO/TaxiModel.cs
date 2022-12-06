namespace TaxiGoAPI.DBO
{
    public class TaxiModel
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public int CarLicense { get; set; }

        public int? DriverId { get; set; }
    }
}
