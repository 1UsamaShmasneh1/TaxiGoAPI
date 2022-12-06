using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxiGoAPI.DBO;
using TaxiGoAPI.Repos;

namespace TaxiGoAPI.Controllers
{
    [Route("taxi/[controller]")]
    [ApiController]
    [Authorize]
    public class DriversController : ControllerBase
    {
        private readonly IDriversRepository _driversRepository;

        public DriversController(IDriversRepository driversRepository)
        {
            _driversRepository = driversRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetDrivers()
        {
            var drivers = await _driversRepository.GetAllDriversAsync();
            return Ok(drivers);
        }

        [HttpPost]
        public async Task<IActionResult> AddDriver([FromBody] DriverModel driver)
        {
            await _driversRepository.AddDriverAsync(driver);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaxi([FromRoute] int id, [FromBody] DriverModel driver)
        {
            await _driversRepository.UpdateDriverAsync(id, driver);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriver([FromRoute] int id)
        {
            await _driversRepository.DeleteDriverAsync(id);
            return Ok();
        }
    }
}
