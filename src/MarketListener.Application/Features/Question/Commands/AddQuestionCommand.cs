namespace MarketListener.Application.Features.Question.Commands;

using System.Collections.Generic;
using Domain.Entities;
using Domain.Enums.Error;
using MarketListener.Domain.Common;
using MarketListener.Domain.Enums;
using MediatR;

public sealed class AddQuestionCommand : IRequest<AddQuestionDto>
{
    public string Title { get; set; } = default!;
    public string Text { get; set; } = default!;
    public QuestionType QuestionType { get; set; }
    public List<string> Tags { get; set; } = default!;
    public bool IsTimeLimited { get; set; }
    public int TimeLimitSeconds { get; set; }
    public int CurrentUserId { get; set; }
    public string Explanation { get; set; }
    public List<AddQuestionAnswerDto> Answers { get; set; }
}
public class AddQuestionAnswerDto
{
    public string Text { get; set; } = default!;
    public bool IsRightAnswer { get; set; }
    public int Order { get; set; }
}
public sealed class AddQuestionDto : ApplicationDto
{    
    public int Id { get; init; }

    public string Title { get; init; } = null!;

    public string TradeCode { get; init; } = null!;

    public AddQuestionDto(Status status, string message = null) : base(status, message)
    {
    }
}

