using Coin.Dispenser.DataAccess.Models;
using Coin.Dispenser.DTO;
using System.Threading.Tasks;

namespace Coin.Dispenser.Services.Interface
{
    public interface ITokenService
    {
        Task<string> GetTokenAsync(UserDetailsDto userDetails);
        Task RegisterUserAsync(string username, string password);
    }
}
