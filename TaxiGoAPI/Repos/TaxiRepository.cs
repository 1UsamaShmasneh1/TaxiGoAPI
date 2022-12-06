using Microsoft.EntityFrameworkCore;
using TaxiGoAPI.DB;
using TaxiGoAPI.DBO;
using TaxiGoAPI.Models;

namespace TaxiGoAPI.Repos
{
    public class TaxiRepository: ITaxiRepository
    {
        private readonly TaxiGoContext _context;

        public TaxiRepository(TaxiGoContext context)
        {
            _context = context;
        }

        public async Task<List<TaxiModel>> GetAllTaxisAsync()
        {
            var records = await _context.Taxis
                                        .Where(t => t.Number != 0)
                                        .Select(t => new TaxiModel
                                        {
                                            Id = t.Id,
                                            Number = t.Number,
                                            CarLicense = t.CarLicense,
                                            DriverId = t.DriverId
                                        })
                                        .ToListAsync();
            return records;
        }

        public async Task UpdateTaxiAsync(int taxiNum, TaxiModel updatedTaxi)
        {
            var taxi = _context.Taxis.FirstOrDefault(t => t.Id == updatedTaxi.Id);
            if (taxi == null) return;
            taxi.Number = updatedTaxi.Number;
            taxi.CarLicense = updatedTaxi.CarLicense;
            taxi.DriverId = updatedTaxi.DriverId;
            _context.Taxis.Update(taxi);
            await _context.SaveChangesAsync();
        }

        public async Task AddTaxiAsync(TaxiModel taxi)
        {
            var newTaxi = new Taxi()
            {
                Number = taxi.Number,
                CarLicense = taxi.CarLicense,
                DriverId = taxi.DriverId
            };
            _context.Taxis.Add(newTaxi);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTaxiAsync(int taxiId)
        {
            var taxi = _context.Taxis.FirstOrDefault(t => t.Id == taxiId);
            var requset = _context.Requests.FirstOrDefault(r => r.TaxiId == taxiId);
            if (requset != null)
            {
                requset.TaxiId = null;
                _context.Requests.Update(requset);
            }

            _context.Taxis.Remove(taxi);
            await _context.SaveChangesAsync();
        }
    }
}
