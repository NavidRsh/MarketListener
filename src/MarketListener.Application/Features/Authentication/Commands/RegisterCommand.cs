namespace MarketListener.Application.Features.Authentication.Commands;

using System.Collections.Generic;
using System.Text.Json.Serialization;
using Domain.Entities;
using Domain.Enums.Error;
using MarketListener.Domain.Common;
using MarketListener.Domain.Enums;
using MarketListener.Domain.Interfaces;
using MediatR;

public sealed class RegisterCommand : IRequest<RegisterDto>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string Email { get; set; } = default!;

}

public sealed class RegisterDto : ApplicationDto, IHasError
{        
    public string FirstName { get; init; } = null!;

    public string LastName { get; init; } = null!;

    public string? UserName { get; init; } = null!;

    [JsonIgnore]
    public List<Error> Errors { get; set; }

    public RegisterDto(Status status, string message = null) : base(status, message)
    {
    }
}

