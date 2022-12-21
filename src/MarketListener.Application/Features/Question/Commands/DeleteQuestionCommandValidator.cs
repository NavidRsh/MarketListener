namespace MarketListener.Application.Features.Question.Commands;
using FluentValidation;
using MarketListener.Domain.Common;

public class DeleteQuestionCommandValidator : AbstractValidator<DeleteQuestionCommand>
{
    public DeleteQuestionCommandValidator()
    {
        RuleFor(command => command.Id).NotNull().NotEmpty()
            .WithMessage(Resources.QuestionIdNotEntered);      
    }   
}
