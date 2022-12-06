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
    public class RequestsController : ControllerBase
    {
        private readonly IRequestsRepository _requestsRepository;

        public RequestsController(IRequestsRepository requestsRepository)
        {
            _requestsRepository = requestsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetRequests()
        {
            var requests = await _requestsRepository.GetAllRequestsAsync();
            return Ok(requests);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRequestById([FromRoute] int id)
        {
            var request = await _requestsRepository.GetRequestByIdAsync(id);
            if (request == null)
                return NotFound();
            return Ok(request);
        }



        [HttpPost]
        public async Task<IActionResult> AddRequest([FromBody] RequestModel request)
        {
            int requestId = await _requestsRepository.AddRequestAsync(request);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRequest([FromRoute] int id, [FromBody] RequestModel request)
        {
            await _requestsRepository.UpdateRequestAsync(id, request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest([FromRoute] int id)
        {
            await _requestsRepository.DeleteRequestAsync(id);
            return Ok();
        }
    }
}
