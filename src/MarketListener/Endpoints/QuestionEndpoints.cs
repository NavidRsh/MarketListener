using MarketListener.Application.Features.Question.Commands;
using MarketListener.Application.Features.Question.Queries;
using MarketListener.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OpenApi;
namespace MarketListener.Endpoints;

public static class QuestionEndpoints
{
    public static void MapQuestionEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Question").WithTags(nameof(Question));

        group.MapGet("/", async (IMediator mediator) =>
        {
            return EndpointBase.CreateResult<ListQuestionQueryDto>(await mediator.Send(new ListQuestionQuery()));
        })
        .WithName("GetAllQuestions")
        .WithOpenApi();

        group.MapGet("/{id}", (int id) =>
        {
            //return new Question { ID = id };
        })
        .WithName("GetQuestionById")
        .WithOpenApi();

        group.MapPut("/{id}", (int id, Question input) =>
        {
            return TypedResults.NoContent();
        })
        .WithName("UpdateQuestion")
        .WithOpenApi();

        group.MapPost("/Add", async (IMediator mediator, HttpContext context, AddQuestionCommand model) =>
        {
            model.CurrentUserId = EndpointBase.GetUserId(context.User);

            var userName = EndpointBase.GetUserName(context.User);

            return EndpointBase.CreateResult<AddQuestionDto>(await mediator.Send(model));
        })
        .WithName("CreateQuestion")
        .WithOpenApi();

        group.MapDelete("/{id}", [Authorize(Roles = "Administrator")](int id) =>
        {
            //return TypedResults.Ok(new Question { ID = id });
        })
        .WithName("DeleteQuestion")
        .WithOpenApi();
    }
}
