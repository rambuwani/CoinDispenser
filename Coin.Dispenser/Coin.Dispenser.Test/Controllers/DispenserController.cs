using AutoFixture.Xunit2;
using Coin.Dispenser.DTO;
using Coin.Dispenser.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Coin.Dispenser.Test.Controllers
{
    public class DispenserController
    {
        private readonly Dispenser.Controllers.DispenserController _controller;

        public DispenserController()
        {
            _controller = new Dispenser.Controllers.DispenserController(
                    new Infrastructure.Services.DispenserService.Mock());
        }

        [Fact]
        public async Task ItReturnsCoinsAsync()
        {
            var response = await _controller.GetCoinsAsync();

            Assert.IsType<ApiResponse>(response);
            Assert.NotNull(response.Result);
            Assert.Null(response.Message);
        }

        [Theory, AutoData]
        public void ItPostsCoinDispenserRequestSuccessfully(CoinDispenserRequestDto model)
        {
            var response = _controller.PostCoins(model);

            Assert.IsType<ApiResponse>(response);
            Assert.NotNull(response.Result);
            Assert.Null(response.Message);
        }


        [Fact]
        public async Task ItCatchesUnhandledExceptionsAndReturnsNullWhenUnsuccessfullyGettingCoinsAsync()
        {
            var exceptionController = new Dispenser.Controllers.DispenserController(
                    new Infrastructure.Services.DispenserService.MockException()
                );
            var response =await exceptionController.GetCoinsAsync();
            Assert.IsType<ApiResponse>(response);
            Assert.Null(response.Result);
        }

        [Theory, AutoData]
        public void ItCatchesUnhandledExceptionsAndReturnsWhenPostingCoinDispenserCoinNullAsync(CoinDispenserRequestDto model)
        {
            var exceptionController = new Dispenser.Controllers.DispenserController(
                    new Infrastructure.Services.DispenserService.MockException()
                );
            var response =  exceptionController.PostCoins(model);
            Assert.IsType<ApiResponse>(response);
            Assert.Null(response.Result);
        }
    }
}

