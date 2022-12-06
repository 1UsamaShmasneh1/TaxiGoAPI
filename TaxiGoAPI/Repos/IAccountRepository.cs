using Microsoft.AspNetCore.Identity;
using TaxiGoAPI.DBO;
using TaxiGoAPI.Models;

namespace TaxiGoAPI.Repos
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignupAsync(SignupModel signupModel);

        Task<object> LoginAsync(SignInModel signInModel);

        Task SignOutAsync();
    }
}
