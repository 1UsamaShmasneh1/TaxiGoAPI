using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace TaxiGoAPI.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Role { get; set; }
    }
}
