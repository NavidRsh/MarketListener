namespace MarketListener.Application.Features.Authentication.Commands;

using System.Collections.Generic;
using Domain.Entities;
using Domain.Enums.Error;
using MarketListener.Domain.Common;
using MarketListener.Domain.Enums;
using MediatR;

public sealed class RegisterCommand : IRequest<RegisterDto>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string Email { get; set; } = default!;

}

public sealed class RegisterDto : ApplicationDto
{    
    public int UserId { get; init; }

    public string FirstName { get; init; } = null!;

    public string LastName { get; init; } = null!;

    public string? UserName { get; init; } = null!;

    public RegisterDto(Status status, string message = null) : base(status, message)
    {
    }
}

