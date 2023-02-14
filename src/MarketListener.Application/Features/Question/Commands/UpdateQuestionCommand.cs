namespace MarketListener.Application.Features.Question.Commands;

using System.Collections.Generic;
using Domain.Entities;
using Domain.Enums.Error;
using MarketListener.Domain.Common;
using MarketListener.Domain.Enums;
using MediatR;

public sealed class UpdateQuestionCommand : IRequest<UpdateQuestionDto>
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string Text { get; set; } = default!;
    public QuestionType QuestionType { get; set; }
    public List<string> Tags { get; set; } = default!;
    public bool IsTimeLimited { get; set; }
    public int TimeLimitSeconds { get; set; }
    public string Explanation { get; set; }
    public List<UpdateQuestionAnswerDto> Answers { get; set; } = new(); 
}

public class UpdateQuestionAnswerDto
{
    public string Text { get; set; } = default!;
    public bool IsRightAnswer { get; set; }
    public int Order { get; set; }
}


public sealed class UpdateQuestionDto : ApplicationDto
{    
    public UpdateQuestionDto(Status status, string message = null) : base(status, message)
    {
    }
}

