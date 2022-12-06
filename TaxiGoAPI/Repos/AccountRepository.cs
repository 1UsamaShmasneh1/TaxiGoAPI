using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaxiGoAPI.DBO;
using TaxiGoAPI.Models;

namespace TaxiGoAPI.Repos
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountRepository(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<IdentityResult> SignupAsync(SignupModel signupModel)
        {
            var usr = _userManager.Users.FirstOrDefault(u => u.Email == signupModel.Email);//.FindByEmailAsync(signupModel.Email);
            var user = new ApplicationUser
            {
                FirstName = signupModel.FirstName,
                LastName = signupModel.LastName,
                PhoneNumber = signupModel.phoneNumber,
                Role = signupModel.Role,
                Email = signupModel.Email,
                UserName = signupModel.Email
            };

            if (usr != null)
            {
                return IdentityResult.Failed(new IdentityError[] {new IdentityError{ Code = "0001", Description = "conflict" }});
            }

            return await _userManager.CreateAsync(user, signupModel.Password);
        }

        public async Task<object> LoginAsync(SignInModel signInModel)
        {
            var result = await _signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, false, false);

            if (!result.Succeeded)
            {
                return null;
            }

            var usr = _userManager.Users.FirstOrDefault(u => u.Email == signInModel.Email);

            var myClaiims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, signInModel.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, usr.Role)
            };

            var authSigninKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudeience"],
                expires: DateTime.UtcNow.AddHours(10),
                claims: myClaiims,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256Signature)
                );
            return new {Roles = usr.Role, User = usr, Token = new JwtSecurityTokenHandler().WriteToken(token)};
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
