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

public sealed class ToggleActiveHandler : IRequestHandler<ToggleActiveCommand, ToggleActiveDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public ToggleActiveHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ToggleActiveDto> Handle(ToggleActiveCommand command, CancellationToken cancellationToken)
    {
        var question = await _unitOfWork.QuestionRepository.GetAsync(command.Id);

        question.ToggleActive();

        await _unitOfWork.SaveChangesAsync();

        return new ToggleActiveDto(Status.Ok, "");
    }
}