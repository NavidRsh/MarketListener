namespace MarketListener.Application.Features.Authentication.Commands;
using FluentValidation;
using MarketListener.Domain.Common;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(command => command.UserName).NotNull()
            .NotEmpty()
            .WithMessage(Resources.UserNameNotEntered);

        RuleFor(command => command.Password).NotNull()
            .NotEmpty()
            .WithMessage(Resources.PasswordNotEntered);

        RuleFor(command => command.ApplicationCode).NotNull()
            .WithMessage(Resources.ApplicationCodeNotValid);


    }
}
