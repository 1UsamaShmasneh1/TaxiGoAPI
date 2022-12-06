using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaxiGoAPI.DBO;
using TaxiGoAPI.Repos;

namespace TaxiGoAPI.Controllers
{
    [Route("taxi/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] SignupModel signupModel)
        {
            var result = await _accountRepository.SignupAsync(signupModel);
            
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }

            List<IdentityError> errorList = result.Errors.ToList();

            if (errorList.Any())
            {
                foreach (var error in errorList)
                {
                    if (error.Code == "0001")
                        return Conflict();
                }
            }

            return Unauthorized();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(SignInModel signInModel)
        {
            var result = await _accountRepository.LoginAsync(signInModel);

            if (result == null)
            {
                return Unauthorized();
            }

            return Ok(result);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountRepository.SignOutAsync();

            return Ok(); //RedirectToAction("Index");
        }
    }
}
