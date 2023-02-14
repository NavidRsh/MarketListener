namespace MarketListener.Application.Features.Question.Commands;

using System.Collections.Generic;
using Domain.Entities;
using Domain.Enums.Error;
using MarketListener.Domain.Common;
using MarketListener.Domain.Enums;
using MediatR;

public sealed class ToggleActiveCommand : IRequest<ToggleActiveDto>
{
    public int Id { get; set; } = default!;   
}
public sealed class ToggleActiveDto : ApplicationDto
{    
    public ToggleActiveDto(Status status, string message = null) : base(status, message)
    {
    }
}

