using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxiGoAPI.Models;
using TaxiGoAPI.Repos;

namespace TaxiGoAPI.Controllers
{
    [Route("taxi/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {

            var result = await _userRepository.GetUsersAsync();

            return Ok(result);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetUserByEmail([FromRoute] string email)
        {

            var result = await _userRepository.GetUserByEmailAsync(email);

            return Ok(result);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser([FromRoute]string userId, [FromBody]ApplicationUser modifiedUser)
        {
            await _userRepository.UpdateUserAsync(userId, modifiedUser);
            return CreatedAtAction(nameof(GetUsers), null, null);
        }

        [HttpDelete("{deleteId}")]
        public async Task<IActionResult> DeleteUser([FromRoute] string deleteId)
        {
            var result = await _userRepository.DeleteUsertAsync(deleteId);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return NotFound();
        }
    }
}
