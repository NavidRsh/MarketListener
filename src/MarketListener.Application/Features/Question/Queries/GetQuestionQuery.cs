namespace MarketListener.Application.Features.Question.Queries;

using MarketListener.Domain.Common;
using MarketListener.Domain.Entities;
using MarketListener.Domain.Enums;
using MarketListener.Domain.Enums.Error;
using MarketListener.Domain.ValueObjects;
using MediatR;
using Sieve.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public sealed class GetQuestionQuery : IRequest<GetQuestionQueryDto>
{   
    public int Id { get; init; }
}

public sealed class GetQuestionQueryDto : ApplicationDto
{
    public int Id { get; init; }
    public string Title { get; set; } = default!;
    public string Text { get; set; } = default!;
    public QuestionType QuestionType { get; set; }
    public List<string> Tags { get; set; } = default!;
    public bool IsTimeLimited { get; set; }
    public int TimeLimitSeconds { get; set; }
    public string Explanation { get; set; }
    public List<QuestionAnswerDtoItem> Answers { get; set; } = default!;
    public GetQuestionQueryDto(Status status, string message = "") : base(status, message)
    {
        
    }
}

public class QuestionAnswerDtoItem
{
    public string Text { get; set; } = default!;
    public bool IsRightAnswer { get; set; }
    public int Order { get; set; }
}


