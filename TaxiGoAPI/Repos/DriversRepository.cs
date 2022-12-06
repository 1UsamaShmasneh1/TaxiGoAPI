using Microsoft.EntityFrameworkCore;
using TaxiGoAPI.DB;
using TaxiGoAPI.DBO;
using TaxiGoAPI.Models;

namespace TaxiGoAPI.Repos
{
    public class DriversRepository: IDriversRepository
    {
        private readonly TaxiGoContext _context;

        public DriversRepository(TaxiGoContext context)
        {
            _context = context;
        }

        public async Task<List<DriverModel>> GetAllDriversAsync()
        {
            var records = await _context.Drivers
                                        .Select(d => new DriverModel
                                        {
                                            Id = d.Id,
                                            FirstName = d.FirstName,
                                            LastName = d.LastName,
                                            UserId = d.UserId
                                        })
                                        .ToListAsync();
            return records;
        }

        public async Task AddDriverAsync(DriverModel driver)
        {
            var newDriver = new Driver()
            {
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                UserId = driver.UserId
            };
            _context.Drivers.Add(newDriver);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDriverAsync(int id, DriverModel modifiedDriver)
        {
            var driver = new Driver()
            {
                Id = id,
                FirstName = modifiedDriver.FirstName,
                LastName = modifiedDriver.LastName,
                UserId = modifiedDriver.UserId
            };

            _context.Drivers.Update(driver);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteDriverAsync(int driverId)
        {
            var taxi = _context.Taxis.FirstOrDefault(t => t.DriverId == driverId);
            if(taxi != null)
            {
                taxi.DriverId = null;
                _context.Taxis.Update(taxi);
            }
            var driver = new Driver()
            {
                Id = driverId
            };
            _context.Drivers.Remove(driver);
            await _context.SaveChangesAsync();
        }
    }
}
