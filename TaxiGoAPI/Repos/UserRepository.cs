using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaxiGoAPI.Models;

namespace TaxiGoAPI.Repos
{
    public class UserRepository: IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public UserRepository(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<List<ApplicationUser>> GetUsersAsync()
        {

            var users = await _userManager.Users.ToListAsync();

            return users;
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {

            var user = await _userManager.Users.Where(u => u.Email == email).FirstOrDefaultAsync();

            return user;
        }

        public async Task UpdateUserAsync(string userId, ApplicationUser modifiedUser)
        {
            var usr = _userManager.Users.FirstOrDefault(u => u.Id == userId);
            if (usr != null)
            {
                usr.FirstName = modifiedUser.FirstName;
                usr.LastName = modifiedUser.LastName;
                usr.Email = modifiedUser.Email;
                usr.PhoneNumber = modifiedUser.PhoneNumber;
                await _userManager.UpdateAsync(usr);
            }
        }

        public async Task<IdentityResult> DeleteUsertAsync(string id)
        {
            var usr = _userManager.Users.FirstOrDefault(u => u.Id == id);
            return await _userManager.DeleteAsync(usr);
        }
    }
}
