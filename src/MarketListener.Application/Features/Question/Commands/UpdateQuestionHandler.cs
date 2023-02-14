namespace MarketListener.Application.Features.Question.Commands;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Enums.Error;
using Domain.Entities;
using Gateways.Repositories;
using MediatR;
using Domain.Common;
using MarketListener.Domain.ValueObjects;
using static System.Net.Mime.MediaTypeNames;

public sealed class UpdateQuestionHandler : IRequestHandler<UpdateQuestionCommand, UpdateQuestionDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateQuestionHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateQuestionDto> Handle(UpdateQuestionCommand command, CancellationToken cancellationToken)
    {
        var question = await _unitOfWork.QuestionRepository.GetQuestionAsync(command.Id);
        if (question is null)
            return new UpdateQuestionDto(Status.BadRequest, Resources.QuestionNotFound);

        question.Update(command.Title, command.Text, command.QuestionType, 
            command.Tags != null ? command.Tags.Select(a => TagLabel.Create(a)).ToList() : new List<TagLabel>(),
            command.IsTimeLimited, command.TimeLimitSeconds, command.Explanation);

        question.Answers.Clear();
        _unitOfWork.QuestionRepository
            .RemoveAnswers(command.Id);

        question.Answers
            .AddRange(command.Answers.Where(a => !string.IsNullOrEmpty(a.Text))
            .Select(a => Answer.Create(a.Text, question.Id, a.IsRightAnswer, a.Order))
            .ToList());

        await _unitOfWork.SaveChangesAsync();

        return new UpdateQuestionDto(Status.Ok, "");
    }
}