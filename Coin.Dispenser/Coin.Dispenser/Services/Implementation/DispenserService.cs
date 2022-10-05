using Coin.Dispenser.DataAccess;
using Coin.Dispenser.DTO;
using Coin.Dispenser.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coin.Dispenser.Services.Implementation
{
    public class DispenserService: IDispenserService
    {
        private readonly CoinDispenserDataContext _context;
        public DispenserService(CoinDispenserDataContext context)
        {
            _context = context;
        }
        public CoinDispenserResponseDto CoinsDispenser(CoinDispenserRequestDto requestDto)
        {
            CoinDispenserResponseDto responseDto = new();
            if (requestDto == null)
                return null;

            //Get all coins selected-- this is an Array
            var listCoins = requestDto.Coins;

            //Sort All coins and reverse them to start with the Highest amount
            listCoins.Sort();
            listCoins.Reverse();

            //This will store the coin and quantity of coin to be returned
            Dictionary<int, int> combinations = new();
            double amount =requestDto.Amount;

            List<CombinationDto> combinationDtos = new();


            foreach (int coin in listCoins)
            {
                int count = 0;
                //The coin should be less than amount
                while (coin <= amount)
                {
                    count++;
                    //Subtract coin from amount
                    amount -= coin;

                    if (!combinations.ContainsKey(coin))
                    {
                        combinations.Add(coin, count);
                    }
                    else
                    {
                        combinations.Remove(coin);
                        combinations.Add(coin, count);
                    }
                   
                }
            }

            foreach (var item in combinations)
            {
                CombinationDto cDto = new();
                cDto.Coin =item.Key;
                cDto.Number =item.Value;
                combinationDtos.Add(cDto);
            }

            responseDto.Combination = combinationDtos;

            return  responseDto;
        }

        public async Task<List<DataAccess.Models.CoinCheckBox>> GetCoinCheckBoxes()
        {
            
            var coinCheckBoxes = await _context.CoinCheckBoxes.
                                    ToListAsync()
                                   .ConfigureAwait(false);
            return coinCheckBoxes;
        }
    }
}

