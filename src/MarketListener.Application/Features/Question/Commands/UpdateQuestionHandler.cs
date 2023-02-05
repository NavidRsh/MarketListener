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

public sealed class UpdateQuestionHandler : IRequestHandler<UpdateQuestionCommand, UpdateQuestionDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateQuestionHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateQuestionDto> Handle(UpdateQuestionCommand command, CancellationToken cancellationToken)
    {
        var Question = await _unitOfWork.QuestionRepository.GetQuestionAsync(command.Id);
        if (Question is null)
            return new UpdateQuestionDto(Status.BadRequest, Resources.QuestionNotFound);

        Question.Update(command.Title, command.Text, command.QuestionType, 
            command.Tags.Select(a => TagLabel.Create(a)).ToList(),
            command.IsTimeLimited, command.TimeLimitSeconds);

        Question.Answers.Clear();
        _unitOfWork.QuestionRepository.RemoveAnswers(command.Id);

        Question.Answers.AddRange(command.Answers.Select(a => new Answer()
        {
            IsRightAnswer = a.IsRightAnswer,
            Order = a.Order,
            Text = a.Text            
        }).ToList());

        await _unitOfWork.SaveChangesAsync();

        return new UpdateQuestionDto(Status.Ok, "");
    }
}