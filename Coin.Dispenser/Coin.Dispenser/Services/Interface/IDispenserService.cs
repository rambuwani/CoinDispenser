using Coin.Dispenser.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coin.Dispenser.Services.Interface
{
    public interface IDispenserService
    {
        CoinDispenserResponseDto CoinsDispenser(CoinDispenserRequestDto requestDto);
        Task<List<DataAccess.Models.CoinCheckBox>> GetCoinCheckBoxes();
    }
}
