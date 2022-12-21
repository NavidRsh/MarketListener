namespace MarketListener.Application.Features.Question.Commands;
using FluentValidation;
using MarketListener.Domain.Common;

public class AddQuestionCommandValidator : AbstractValidator<AddQuestionCommand>
{
    public AddQuestionCommandValidator()
    {
        RuleFor(command => command.Title).NotNull()
            .NotEmpty()
            .WithMessage(Resources.QuestionTitleNotEntered);

        
    }   
}
