using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Coin.Dispenser.DTO
{
    public class CoinDispenserRequestDto
    {
        [Required]
        [JsonProperty("coins")]
        public List<int> Coins { get; set; }
        [Required]
        [JsonProperty("amount")]
        public double Amount { get; set; }
    }

}
