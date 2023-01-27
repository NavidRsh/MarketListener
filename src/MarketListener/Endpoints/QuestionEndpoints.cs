using Azure.Core;
using MarketListener.Application.Features.Question.Commands;
using MarketListener.Application.Features.Question.Queries;
using MarketListener.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore.Design.Internal;

namespace MarketListener.Endpoints;

public static class QuestionEndpoints
{
    public static void MapQuestionEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Question").WithTags(nameof(Question));

        group.MapPost("/", async (IMediator mediator, HttpContext context) =>
        {
            
            var draw = context.Request.Form["draw"].FirstOrDefault();
            var start = context.Request.Form["start"].FirstOrDefault();
            var length = context.Request.Form["length"].FirstOrDefault();
            var sortColumn = context.Request.Form["columns[" + context.Request.Form["order[0][column]"].FirstOrDefault()
                + "][name]"].FirstOrDefault();
            var sortColumnDirection = context.Request.Form["order[0][dir]"].FirstOrDefault();
            var searchValue = context.Request.Form["search[value]"].FirstOrDefault();

            int recordsTotal = 0;

            ListQuestionQuery query = new ListQuestionQuery() { 
                SieveModel = new Sieve.Models.SieveModel() { 
                    PageSize = length != null ? Convert.ToInt32(length) : 10,
                    Page = (start != null && start != "0") ? (Convert.ToInt32(start) / Convert.ToInt32(length)) + 1 : 1
                },
                Draw = Convert.ToInt32(draw)
            }; 

            return EndpointBase.CreateResult<ListQuestionQueryDto>(await mediator.Send(query));
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
