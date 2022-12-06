using TaxiGoAPI.DBO;

namespace TaxiGoAPI.Repos
{
    public interface IDriversRepository
    {
        Task<List<DriverModel>> GetAllDriversAsync();

        Task AddDriverAsync(DriverModel driver);

        Task UpdateDriverAsync(int id, DriverModel modifiedDriver);

        Task DeleteDriverAsync(int driverId);
    }
}
