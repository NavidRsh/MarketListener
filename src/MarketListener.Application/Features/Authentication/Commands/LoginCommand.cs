namespace MarketListener.Application.Features.Authentication.Commands;

using System.Collections.Generic;
using Domain.Entities;
using Domain.Enums.Error;
using MarketListener.Domain.Common;
using MarketListener.Domain.Enums;
using MarketListener.Domain.Interfaces;
using MediatR;

public sealed class LoginCommand : IRequest<LoginDto>
{
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;    
    public ApplicationCode? ApplicationCode { get; set; }
}

public sealed class LoginDto : ApplicationDto, IHasError
{    
    public int UserId { get; init; }

    public string FirstName { get; init; } = null!;

    public string LastName { get; init; } = null!;

    public string? UserName { get; init; } = null!;

    public string AccessToken { get; init; } = null!;

    public List<Error> Errors { get; set; }
    public LoginDto(Status status, string message = null) : base(status, message)
    {
    }
}

