namespace MarketListener.Application.Features.Question.Commands;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Enums.Error;
using Domain.Entities;
using Gateways.Repositories;
using MediatR;
using Domain.Common;

public sealed class DeleteQuestionHandler : IRequestHandler<DeleteQuestionCommand, DeleteQuestionDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteQuestionHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DeleteQuestionDto> Handle(DeleteQuestionCommand command, CancellationToken cancellationToken)
    {
        var Question = await _unitOfWork.QuestionRepository.GetAsync(command.Id);
        if (Question is null)
            return new DeleteQuestionDto(Status.BadRequest, Resources.QuestionNotFound);

        _unitOfWork.QuestionRepository.Delete(Question); 

        await _unitOfWork.SaveChangesAsync();

        return new DeleteQuestionDto(Status.Ok, "");
    }
}