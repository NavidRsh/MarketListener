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

public sealed class LoginHandler : IRequestHandler<LoginCommand, LoginDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthManager _authManager;
    private readonly IConfiguration _configuration;
    public LoginHandler(IUnitOfWork unitOfWork, IConfiguration configuration, IAuthManager authManager)
    {
        _unitOfWork = unitOfWork;
        _configuration = configuration;
        _authManager = authManager;
    }

    public async Task<LoginDto> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        var loginResponse = await _authManager.Login(new Gateways.AuthManager.Models.LoginRequest()
        {
            Password = command.Password,
            UserName = command.UserName
        });

        if (loginResponse == null)
        {
            return new LoginDto(Status.Unauthorized, Resources.InvalidCredentials);
        };


        return new LoginDto(Status.Ok, "")
        {
            UserName = loginResponse.UserName,
            AccessToken = loginResponse.Token,
            FirstName = loginResponse.FirstName,
            LastName = loginResponse.LastName,
            UserId = loginResponse.UserId
        };
    }


}