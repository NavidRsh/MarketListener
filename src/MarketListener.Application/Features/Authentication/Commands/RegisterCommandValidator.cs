namespace MarketListener.Application.Features.Authentication.Commands;
using FluentValidation;
using MarketListener.Domain.Common;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(command => command.UserName).NotNull()
            .NotEmpty()
            .WithMessage(Resources.UserNameNotEntered);

        RuleFor(command => command.Password).NotNull()
            .NotEmpty()
            .WithMessage(Resources.PasswordNotEntered);

    }
}
