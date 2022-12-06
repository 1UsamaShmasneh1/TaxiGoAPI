using System.ComponentModel.DataAnnotations;

namespace TaxiGoAPI.Models
{
    public class Driver
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string? UserId { get; set; }

        public ApplicationUser? User { get; set; }
    }
}
