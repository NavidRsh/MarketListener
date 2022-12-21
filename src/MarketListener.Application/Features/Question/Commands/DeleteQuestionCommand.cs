namespace MarketListener.Application.Features.Question.Commands;

using System.Collections.Generic;
using Domain.Entities;
using Domain.Enums.Error;
using MarketListener.Domain.Common;
using MediatR;

public sealed class DeleteQuestionCommand : IRequest<DeleteQuestionDto>
{
    public int Id { get; init; }    
}

public sealed class DeleteQuestionDto : ApplicationDto
{    
    public DeleteQuestionDto(Status status, string message = null) : base(status, message)
    {
    }
}

