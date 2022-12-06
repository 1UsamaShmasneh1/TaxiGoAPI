using Microsoft.AspNetCore.Identity;
using TaxiGoAPI.Models;

namespace TaxiGoAPI.Repos
{
    public interface IUserRepository
    {
        Task<List<ApplicationUser>> GetUsersAsync();

        Task<IdentityResult> DeleteUsertAsync(string id);

        Task UpdateUserAsync(string userId, ApplicationUser modifiedUser);

        Task<ApplicationUser> GetUserByEmailAsync(string email);
    }
}
