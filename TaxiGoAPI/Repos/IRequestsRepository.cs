using TaxiGoAPI.DBO;

namespace TaxiGoAPI.Repos
{
    public interface IRequestsRepository
    {
        Task<List<RequestModel>> GetAllRequestsAsync();

        Task<RequestModel> GetRequestByIdAsync(int id);

        Task<int> AddRequestAsync(RequestModel request);

        Task UpdateRequestAsync(int requestId, RequestModel modifiedRequest);

        Task DeleteRequestAsync(int requestId);
    }
}
