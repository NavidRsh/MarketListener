namespace MarketListener.Application.Features.Authentication.Commands;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Enums.Error;
using Domain.Entities;
using Gateways.Repositories;
using MediatR;
using Domain.Common;
using MarketListener.Application.Gateways.Repositories.User;
using System;
using Microsoft.Extensions.Configuration;
using System.Text;
using MarketListener.Application.Gateways.AuthManager;

public sealed class RegisterHandler : IRequestHandler<RegisterCommand, RegisterDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthManager _authManager;
    private readonly IConfiguration _configuration;
    public RegisterHandler(IUnitOfWork unitOfWork, IConfiguration configuration, IAuthManager authManager)
    {
        _unitOfWork = unitOfWork;
        _configuration = configuration;
        _authManager = authManager;
    }

    public async Task<RegisterDto> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        var RegisterResponse = await _authManager.Register(new Gateways.AuthManager.Models.RegisterRequest()
        {
            Password = command.Password,
            UserName = command.UserName,
            Email = command.Email,
            FirstName = command.FirstName,  
            LastName = command.LastName
        });

        

        return new RegisterDto(Status.Ok, "")
        {
            
        };
    }


}