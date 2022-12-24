namespace MarketListener.Api.Endpoints;

using MarketListener.Application.Features.Authentication.Commands;
using MarketListener.Application.Features.Question.Commands;
using MarketListener.Domain.Entities;
using MediatR;

public static class AuthenticationEndpoints
{
    public static void MapAuthenticationEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapPost("/api/authentication/login/", async (IMediator mediator, LoginCommand model) =>
        {
            return EndpointBase.CreateResult<LoginDto>(await mediator.Send(model));
        })
        .WithTags("Authentication")
        .WithName("Login")
        .WithOpenApi()
        .AllowAnonymous();

        routes.MapPost("/api/authentication/register/", async (IMediator mediator, LoginCommand model) =>
        {
            return EndpointBase.CreateResult<LoginDto>(await mediator.Send(model));
        })
       .WithTags("Authentication")
       .WithName("Register")
       .WithOpenApi()
       .AllowAnonymous();
    }
}
