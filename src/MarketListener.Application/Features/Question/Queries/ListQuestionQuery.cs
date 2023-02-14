namespace MarketListener.Application.Features.Question.Queries;

using MarketListener.Domain.Common;
using MarketListener.Domain.Entities;
using MarketListener.Domain.Enums;
using MarketListener.Domain.Enums.Error;
using MarketListener.Domain.ValueObjects;
using MediatR;
using Sieve.Attributes;
using Sieve.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public sealed class ListQuestionQuery : IRequest<ListQuestionQueryDto>
{
    public SieveModel? SieveModel { get; init; }

    public int Draw { get; init; }
}

public sealed class ListQuestionQueryDto : ApplicationDto
{
    public List<ListQuestionQueryDtoItem>? List { get; set; }
    public long Count { get; init; }
    public int Draw { get; init; }
    public ListQuestionQueryDto(Status status, string message = "") : base(status, message)
    {
        
    }
}

public class ListQuestionQueryDtoItem
{
    [Sieve(CanSort = true, CanFilter = true)]
    public int Id { get; init; }
    [Sieve(CanSort = true, CanFilter = true)]
    public string Title { get; set; } = default!;
    [Sieve(CanSort = true, CanFilter = true)]
    public string Text { get; set; } = default!;
    [Sieve(CanSort = true, CanFilter = true)]
    public QuestionType QuestionType { get; set; }
    [Sieve(CanSort = true, CanFilter = true)]
    public List<TagLabel> Tags { get; set; } = default!;
    [Sieve(CanSort = true, CanFilter = true)]
    public bool IsTimeLimited { get; set; }
    [Sieve(CanSort = true, CanFilter = true)]
    public int TimeLimitSeconds { get; set; }
    [Sieve(CanSort = true, CanFilter = true)]
    public bool IsActive { get; set; }
}