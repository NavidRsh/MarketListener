namespace MarketListener.Application.Features.Question.Commands;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Enums.Error;
using Domain.Entities;
using Gateways.Repositories;
using MediatR;
using Domain.Common;

public sealed class UpdateQuestionHandler : IRequestHandler<UpdateQuestionCommand, UpdateQuestionDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateQuestionHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateQuestionDto> Handle(UpdateQuestionCommand command, CancellationToken cancellationToken)
    {
        var Question = await _unitOfWork.QuestionRepository.GetAsync(command.Id);
        if (Question is null)
            return new UpdateQuestionDto(Status.BadRequest, Resources.QuestionNotFound);

        Question.Update(command.Title, command.Text, command.QuestionType, command.Tags, command.IsTimeLimited, command.TimeLimitSeconds);

        await _unitOfWork.SaveChangesAsync();

        return new UpdateQuestionDto(Status.Ok, "");
    }
}