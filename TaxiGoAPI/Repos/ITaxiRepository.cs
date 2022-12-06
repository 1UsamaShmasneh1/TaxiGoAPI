using TaxiGoAPI.DBO;

namespace TaxiGoAPI.Repos
{
    public interface ITaxiRepository
    {
        Task<List<TaxiModel>> GetAllTaxisAsync();
        Task UpdateTaxiAsync(int taxiNum, TaxiModel taxiModel);
        Task AddTaxiAsync(TaxiModel taxi);
        Task DeleteTaxiAsync(int taxiId);
    }
}
