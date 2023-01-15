namespace MarketListener.Endpoints;

using FluentValidation;
using MarketListener.Application.Common.Models;
using MarketListener.Application.Features.Authentication.Commands;
using MarketListener.Application.Features.Question.Commands;
using MarketListener.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System;
using static Microsoft.AspNetCore.Http.Results;
using MarketListener.Filters;

public static class AuthenticationEndpoints
{
    public static void MapAuthenticationEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapPost("/api/authentication/login/", async (LoginCommand model, IMediator mediator) =>
        {
            return EndpointBase.CreateResult<LoginDto>(await mediator.Send(model));
        })
        .AddEndpointFilter<ValidationFilter<LoginCommand, LoginDto>>()
        .WithTags("Authentication")
        .WithName("Login")
        .WithOpenApi()
        .AllowAnonymous()
        .Produces(StatusCodes.Status200OK, typeof(GeneralApiResponse<LoginDto>));


        routes.MapPost("/api/authentication/register/", async (IMediator mediator, RegisterCommand model) =>
        {
            return EndpointBase.CreateResult<RegisterDto>(await mediator.Send(model));
        })
       .WithTags("Authentication")
       .WithName("Register")
       .WithOpenApi()
       .AllowAnonymous();
    }
}
