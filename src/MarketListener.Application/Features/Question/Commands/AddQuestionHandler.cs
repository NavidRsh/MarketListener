namespace MarketListener.Application.Features.Question.Commands;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Enums.Error;
using Domain.Entities;
using Gateways.Repositories;
using MediatR;
using Domain.Common;

public sealed class AddQuestionHandler : IRequestHandler<AddQuestionCommand, AddQuestionDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddQuestionHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<AddQuestionDto> Handle(AddQuestionCommand command, CancellationToken cancellationToken)
    {
        var Question = Domain.Entities.Question.Create(command.Title, command.Text, command.QuestionType, 
            command.Tags, command.IsTimeLimited, command.TimeLimitSeconds);

        await _unitOfWork.QuestionRepository.AddAsync(Question);

        await _unitOfWork.SaveChangesAsync();

        return new AddQuestionDto(Status.Ok, "");
    }
}