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

public sealed class AddQuestionHandler : IRequestHandler<AddQuestionCommand, AddQuestionDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddQuestionHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<AddQuestionDto> Handle(AddQuestionCommand command, CancellationToken cancellationToken)
    {
        var tags = new List<string>(); 

        var Question = Domain.Entities.Question.Create(command.Title, command.Text, command.QuestionType, 
            tags.Select(a => TagLabel.Create(a)).ToList(), 
            command.IsTimeLimited, command.TimeLimitSeconds);

        await _unitOfWork.QuestionRepository.AddAsync(Question);

        await _unitOfWork.SaveChangesAsync();

        return new AddQuestionDto(Status.Ok, "");
    }
}