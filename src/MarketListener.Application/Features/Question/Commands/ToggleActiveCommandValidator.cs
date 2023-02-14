namespace MarketListener.Application.Features.Question.Commands;
using FluentValidation;
using MarketListener.Domain.Common;

public class ToggleActiveCommandValidator : AbstractValidator<ToggleActiveCommand>
{
    public ToggleActiveCommandValidator()
    {
       
    }   
}
