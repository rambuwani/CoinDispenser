using Coin.Dispenser.DataAccess.Models;
using Coin.Dispenser.DTO;
using Coin.Dispenser.Infrastructure;
using Coin.Dispenser.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Net;

namespace Coin.Dispenser.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    
    public class AccountController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        public AccountController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ApiResponse> LoginAsync([FromBody] UserDetailsDto userDetailsDto)
        {
            try
            {
                var result = await _tokenService.GetTokenAsync(userDetailsDto)
                                        .ConfigureAwait(false);

                if( result == null)
                {
                    return ApiResponse.CreateErrorResponse("Invalid User", HttpStatusCode.BadRequest);
                }

                return ApiResponse.CreateSuccessResponse(result);

            }
            catch (Exception ex)
            {
                return ApiResponse.CreateErrorResponse(ex.Message);
            }
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ApiResponse> RegisterAsync([FromBody] UserDetailsDto userDetailsDto)
        {
            try
            {
                  await _tokenService.RegisterUserAsync(userDetailsDto.UserName, userDetailsDto.Password)
                        .ConfigureAwait(false);

                return ApiResponse.CreateSuccessResponse("Registered");

            }
            catch (Exception ex)
            {

                return ApiResponse.CreateErrorResponse(ex.Message);
            }
        }
    }
}
