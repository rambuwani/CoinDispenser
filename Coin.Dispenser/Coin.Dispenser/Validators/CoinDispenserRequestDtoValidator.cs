using Coin.Dispenser.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coin.Dispenser.Validators
{
    public class CoinDispenserRequestDtoValidator : AbstractValidator<CoinDispenserRequestDto>
    {
        public CoinDispenserRequestDtoValidator()
        {
            const string ErrorMessage = "{PropertyName} is required and cannot be an empty string";

            RuleFor(x => x.Amount)
                .NotNull()
                .WithMessage(ErrorMessage)
                .NotEmpty()
                .WithMessage(ErrorMessage);
            RuleFor(x => x.Coins)
                .NotNull()
                .WithMessage(ErrorMessage)
                .NotEmpty()
                .WithMessage(ErrorMessage);

        }
    }
}
