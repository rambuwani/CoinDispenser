using AutoFixture.Xunit2;
using Coin.Dispenser.DTO;
using Coin.Dispenser.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Coin.Dispenser.Test.Controllers
{
    public class AccountController
    {
        private readonly Dispenser.Controllers.AccountController _controller;

        public AccountController()
        {
            _controller = new Dispenser.Controllers.AccountController(
                    new Infrastructure.Services.TokenService.Mock());
        }

        [Theory, AutoData]
        public async Task ItReturnsTokenWhenLogginInAsync(UserDetailsDto model)
        {
            var response = await _controller.LoginAsync(model);

            Assert.IsType<ApiResponse>(response);
            Assert.NotNull(response.Result);
            Assert.Null(response.Message);
        }

        [Theory, AutoData]
        public async Task ItRegistersSuccessfullyAsync(UserDetailsDto model)
        {
            var response = await _controller.RegisterAsync(model);

            Assert.IsType<ApiResponse>(response);
            Assert.NotNull(response.Result);
            Assert.Null(response.Message);
        }


        [Theory, AutoData]
        public async Task ItCatchesUnhandledExceptionsAndReturnsNullWhenLogginInAsync(UserDetailsDto model)
        {
            var exceptionController = new Dispenser.Controllers.AccountController(
                    new Infrastructure.Services.TokenService.MockException()
                );
            var response = await exceptionController.LoginAsync(model);
            Assert.IsType<ApiResponse>(response);
            Assert.Null(response.Result);
            Assert.NotNull(response.Message);
        }

        [Theory, AutoData]
        public async Task ItCatchesUnhandledExceptionsAndReturnsNullWhenRegisteringAsync(UserDetailsDto model)
        {
            var exceptionController = new Dispenser.Controllers.AccountController(
                    new Infrastructure.Services.TokenService.MockException()
                );
            var response = await exceptionController.LoginAsync(model);
            Assert.IsType<ApiResponse>(response);
            Assert.Null(response.Result);
            Assert.NotEmpty(response.Message);
        }
    }
}

