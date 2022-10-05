using Coin.Dispenser.Configurations;
using Coin.Dispenser.DataAccess;
using Coin.Dispenser.DataAccess.Models;
using Coin.Dispenser.DTO;
using Coin.Dispenser.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Coin.Dispenser.Services.Implementation
{
    public class TokenService : ITokenService
    {
        private readonly CoinDispenserDataContext _context;
        private readonly JwtOptions _jwtOptions;
        private readonly IPasswordHasher<UserDetailsDto> _hasher;

        public TokenService(CoinDispenserDataContext context, 
                            IOptions<JwtOptions> jwtOptions,
                            IPasswordHasher<UserDetailsDto> hasher)
        {
            _context = context;
            _jwtOptions = jwtOptions.Value;
            _hasher =hasher;

        }
        public async Task<string> GetTokenAsync(UserDetailsDto userDetails)
        {

             var user = await GetUserAsync(userDetails.UserName, userDetails.Password);
            if (user != null)
            {

                var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub,_jwtOptions.Subject),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.Id.ToString()),
                        new Claim("UserName", user.UserName),

                    };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _jwtOptions.Issuer,
                   _jwtOptions.Audience,
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            return null;
          
    }

        public async Task RegisterUserAsync(string username, string password)
        {
            if(!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                var hasher = new PasswordHasher<User>();
                var model = new User()
                {
                    UserName = username,
                    Password = hasher.HashPassword(null, password)
                };
                   _context.Users.Add(model);
                    await  _context.SaveChangesAsync();
              
            }

        }
        private async Task<User> GetUserAsync(string username, string password)
        {
            var userCred = await _context.Users
                        .FirstOrDefaultAsync(u => u.UserName == username).ConfigureAwait(false);

            if (userCred == null)
                return null;

            if (_hasher.VerifyHashedPassword(new UserDetailsDto(), 
                        userCred.Password, password) != PasswordVerificationResult.Success)
                return null;

            return userCred;
        }
    }
}

