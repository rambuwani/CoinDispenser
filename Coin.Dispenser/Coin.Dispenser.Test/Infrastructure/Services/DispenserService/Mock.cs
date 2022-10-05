using Coin.Dispenser.DTO;
using Coin.Dispenser.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coin.Dispenser.Test.Infrastructure.Services.DispenserService
{
    public class Mock : IDispenserService
    {

        public CoinDispenserResponseDto CoinsDispenser(CoinDispenserRequestDto requestDto)
        {
            return new CoinDispenserResponseDto
            {
                Combination = new List<CombinationDto>()
                {
                new CombinationDto
                {
                    Number=1,
                    Coin=10
                },
               new CombinationDto
                {
                    Number=1,
                    Coin=10
                }
                }
            };     
    }

    public Task<List<DataAccess.Models.CoinCheckBox>> GetCoinCheckBoxes()
    {
            return Task.FromResult(new List<DataAccess.Models.CoinCheckBox>()
            {
                new DataAccess.Models.CoinCheckBox
                {
                    Value=1,
                    Text=1
                },
               new DataAccess.Models.CoinCheckBox
                {
                   Value=1,
                    Text=1
                }
            });
        }
}
}
