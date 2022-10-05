using Coin.Dispenser.DTO;
using Coin.Dispenser.Services.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Coin.Dispenser.Test.Infrastructure.Services.TokenService
{
    public class MockException : ITokenService
    {
        public Task<string> GetTokenAsync(UserDetailsDto userDetails)
        {
            throw new ApplicationException("Get Token Error");
        }

        public Task RegisterUserAsync(string username, string password)
        {
            throw new ApplicationException("Register Error");
        }
    }
}
