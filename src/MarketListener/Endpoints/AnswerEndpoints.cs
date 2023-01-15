using Microsoft.EntityFrameworkCore;
using MarketListener.Domain.Entities;
using MarketListener.Persistence.Ef.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace MarketListener.Endpoints;

public static class AnswerEndpoints
{
    public static void MapAnswerEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Answer").WithTags(nameof(Answer));

        group.MapGet("/", async (AppDbContext db) =>
        {
            return await db.Answers.ToListAsync();
        })
        .WithName("GetAllAnswers")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Answer>, NotFound>> (int id, AppDbContext db) =>
        {
            return await db.Answers.FindAsync(id)
                is Answer model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetAnswerById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<NotFound, NoContent>> (int id, Answer answer, AppDbContext db) =>
        {
            var foundModel = await db.Answers.FindAsync(id);

            if (foundModel is null)
            {
                return TypedResults.NotFound();
            }
            
            db.Update(answer);
            await db.SaveChangesAsync();

            return TypedResults.NoContent();
        })
        .WithName("UpdateAnswer")
        .WithOpenApi();

        group.MapPost("/", async (Answer answer, AppDbContext db) =>
        {
            db.Answers.Add(answer);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Answer/{answer.Id}",answer);
        })
        .WithName("CreateAnswer")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok<Answer>, NotFound>> (int id, AppDbContext db) =>
        {
            if (await db.Answers.FindAsync(id) is Answer answer)
            {
                db.Answers.Remove(answer);
                await db.SaveChangesAsync();
                return TypedResults.Ok(answer);
            }

            return TypedResults.NotFound();
        })
        .WithName("DeleteAnswer")
        .WithOpenApi();
    }
}
