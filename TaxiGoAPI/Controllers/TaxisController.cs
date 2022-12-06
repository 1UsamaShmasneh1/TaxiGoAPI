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
    public class TaxisController : ControllerBase
    {
        private readonly ITaxiRepository _taxiRepository;

        public TaxisController(ITaxiRepository taxiRepository)
        {
            _taxiRepository = taxiRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTaxis()
        {
            var taxis = await _taxiRepository.GetAllTaxisAsync();
            return Ok(taxis);
        }

        [HttpPost]
        public async Task<IActionResult> AddTaxi([FromBody] TaxiModel taxiModel)
        {
            await _taxiRepository.AddTaxiAsync(taxiModel);
            return Ok();
        }

        [HttpPut("{taxiNum}")]
        public async Task<IActionResult> UpdateTaxi([FromRoute] int taxiNum, [FromBody] TaxiModel taxiModel)
        {
            await _taxiRepository.UpdateTaxiAsync(taxiNum, taxiModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest([FromRoute] int id)
        {
            await _taxiRepository.DeleteTaxiAsync(id);
            return Ok();
        }
    }
}
