namespace MarketListener.Application.Features.Question.Queries;

using MarketListener.Domain.Common;
using MarketListener.Domain.Entities;
using MarketListener.Domain.Enums;
using MarketListener.Domain.Enums.Error;
using MediatR;
using Sieve.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public sealed class ListQuestionQuery : IRequest<ListQuestionQueryDto>
{
    public SieveModel? SieveModel { get; init; }
}

public sealed class ListQuestionQueryDto : ApplicationDto
{
    public List<ListQuestionQueryDtoItem>? List { get; set; }
    public long Count { get; init; }
    public ListQuestionQueryDto(Status status, string message = "") : base(status, message)
    {
        
    }
}

public class ListQuestionQueryDtoItem
{
    public int Id { get; init; }
    public string Title { get; set; } = default!;
    public string Text { get; set; } = default!;
    public QuestionType QuestionType { get; set; }
    public List<Tag> Tags { get; set; } = default!;
    public bool IsTimeLimited { get; set; }
    public int TimeLimitSeconds { get; set; }
}