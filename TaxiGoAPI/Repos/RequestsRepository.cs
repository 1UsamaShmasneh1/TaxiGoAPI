
using Microsoft.EntityFrameworkCore;
using TaxiGoAPI.DB;
using TaxiGoAPI.DBO;
using TaxiGoAPI.Models;

namespace TaxiGoAPI.Repos
{
    public class RequestsRepository: IRequestsRepository
    {
        private readonly TaxiGoContext _context;

        public RequestsRepository(TaxiGoContext context)
        {
            _context = context;
        }

        public async Task<List<RequestModel>> GetAllRequestsAsync()
        {
            var records = await _context.Requests
                                        .Select(r => new RequestModel
                                        {
                                            Id = r.Id,
                                            UserId = r.UserId,
                                            TaxiId = r.TaxiId,
                                            PassengerCount = r.PassengerCount,
                                            Location = r.Location
                                        })
                                        .ToListAsync();
            return records;
        }

        public async Task<RequestModel> GetRequestByIdAsync(int id)
        {
            var record = await _context.Requests
                                    .Where(r => r.Id == id)
                                    .Select(r => new RequestModel
                                    {
                                        Id = r.Id,
                                        UserId = r.UserId,
                                        TaxiId = r.TaxiId,
                                        PassengerCount = r.PassengerCount,
                                        Location = r.Location
                                    })
                                    .FirstOrDefaultAsync();
            return record;
        }

        public async Task<int> AddRequestAsync(RequestModel r)
        {
            var request = new Request()
            {
                UserId = r.UserId,
                Location = r.Location,
                PassengerCount = r.PassengerCount
            };
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();
            return request.Id;
        }

        public async Task UpdateRequestAsync(int requestId, RequestModel modifiedRequest)
        {
            var request = new Request()
            {
                Id = requestId,
                UserId = modifiedRequest.UserId,
                PassengerCount = modifiedRequest.PassengerCount,
                TaxiId = modifiedRequest.TaxiId,
                Location = modifiedRequest.Location
            };

            _context.Requests.Update(request);

            await _context.SaveChangesAsync();
        }

        
        public async Task DeleteRequestAsync(int requestId)
        {
            var request = new Request()
            {
                Id = requestId
            };
            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();
        }
    }
}
