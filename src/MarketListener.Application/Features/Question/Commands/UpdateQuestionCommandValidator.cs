namespace MarketListener.Application.Features.Question.Commands;
using FluentValidation;
using MarketListener.Domain.Common;

public class UpdateQuestionCommandValidator : AbstractValidator<UpdateQuestionCommand>
{
    public UpdateQuestionCommandValidator()
    {
        RuleFor(command => command.Id).NotNull().NotEmpty()
            .WithMessage(Resources.QuestionIdNotEntered);

        RuleFor(command => command.Title).NotNull()
            .NotEmpty()
            .WithMessage(Resources.QuestionTitleNotEntered);
    }   
}
