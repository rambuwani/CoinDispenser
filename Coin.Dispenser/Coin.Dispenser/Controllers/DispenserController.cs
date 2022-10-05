using Coin.Dispenser.DTO;
using Coin.Dispenser.Infrastructure;
using Coin.Dispenser.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Coin.Dispenser.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class DispenserController : ControllerBase
    {
        private readonly IDispenserService _dispenserService;
        public DispenserController(IDispenserService dispenserService)
        {
            _dispenserService = dispenserService;
        }

        [HttpGet]
        [Route("GetCoins")]
        public async Task<ApiResponse> GetCoinsAsync()
        {
            try
            {
                var result = await _dispenserService.GetCoinCheckBoxes().ConfigureAwait(false);
                return ApiResponse.CreateSuccessResponse(result);
            }
            catch (Exception ex)
            {

                return ApiResponse.CreateErrorResponse(ex.Message);
            }
          
        }

        [HttpPost]
        [Route("PostCoins")]
        public ApiResponse PostCoins([FromBody] CoinDispenserRequestDto coinDispenserRequestDto)
        {
            try
            {
                var response = _dispenserService.CoinsDispenser(coinDispenserRequestDto);

                return ApiResponse.CreateSuccessResponse(response);
            }
            catch (Exception ex)
            {

                return ApiResponse.CreateErrorResponse(ex.Message);
            }
           
        }
    }
}
