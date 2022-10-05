using Coin.Dispenser.DTO;
using FluentValidation;


namespace Coin.Dispenser.Validators
{
    public class UserDetailsDtoValidator : AbstractValidator<UserDetailsDto>
    {
        public UserDetailsDtoValidator()
        {
            const string ErrorMessage = "{PropertyName} is required and cannot be an empty string";

            RuleFor(x => x.UserName)
                .NotNull()
                .WithMessage(ErrorMessage)
                .NotEmpty()
                .WithMessage(ErrorMessage);

            RuleFor(x => x.Password)
                .NotNull()
                .WithMessage(ErrorMessage)
                .NotEmpty()
                .WithMessage(ErrorMessage);

        }
    }
}

