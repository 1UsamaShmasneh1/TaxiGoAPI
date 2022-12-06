using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaxiGoAPI.Models;

namespace TaxiGoAPI.DB
{
    public class TaxiGoContext : IdentityDbContext<ApplicationUser>
    {
        public TaxiGoContext(DbContextOptions<TaxiGoContext> options) : base(options)
        {

        }

        public DbSet<Driver> Drivers { get; set; }

        public DbSet<Taxi> Taxis { get; set; }


        public DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().HasData(
                    new ApplicationUser
                    {
                        FirstName = "Admin",
                        LastName = "Admin",
                        UserName = "admin@admin.com",
                        NormalizedUserName = "ADMIN@ADMIN.COM",
                        Email = "admin@admin.com",
                        NormalizedEmail = "ADMIN@ADMIN.COM",
                        EmailConfirmed = false,
                        PasswordHash = "AQAAAAEAACcQAAAAEJnBTuDUEUN9d/wou7DO753pkuvJ2Gncv5FSavet32eSGTf+8tV5+RIwvrpMnbI7sg==",
                        SecurityStamp = "JLS2C6J7B7CMXKZ7SL3SVLMZ7HRCGBWR",
                        ConcurrencyStamp = "88d1c17a-8ab8-4e68-8253-30a9f2bb6079",
                        PhoneNumber = "0524585648",
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false,
                        LockoutEnd = null,
                        LockoutEnabled = true,
                        AccessFailedCount = 0,
                        Role = "Admin"
                    }
            );
        }

    }
}
