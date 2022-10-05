using Coin.Dispenser.DTO;
using Coin.Dispenser.Services.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Coin.Dispenser.Test.Infrastructure.Services.DispenserService
{
    public class MockException : IDispenserService
    {
        public CoinDispenserResponseDto CoinsDispenser(CoinDispenserRequestDto requestDto)
        {
            throw new ApplicationException("Coin Dispenser Response Error");
        }

        public Task<List<DataAccess.Models.CoinCheckBox>> GetCoinCheckBoxes()
        {
            throw new ApplicationException("Coin CheckBoxes List Error");
        }
    }
}
