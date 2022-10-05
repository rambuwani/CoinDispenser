using Coin.Dispenser.DTO;
using Coin.Dispenser.Services.Interface;
using System.Threading.Tasks;

namespace Coin.Dispenser.Test.Infrastructure.Services.TokenService
{
    public class Mock : ITokenService
    {
        public Task<string> GetTokenAsync(UserDetailsDto userDetails)
        {
            return Task.FromResult("JWT");
        }

        public async Task RegisterUserAsync(string username, string password)
        {
            await Task.CompletedTask;
        }
    }
}
