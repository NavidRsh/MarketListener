namespace MarketListener.Domain.Entities;

using MarketListener.Domain.Common;
using MarketListener.Domain.Enums;
using MarketListener.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Answer : Entity<int>
{
    public string Text { get; set; } = default!;
    public int QuestionId { get; set; }
    public Question? Question { get; set; }
    public bool IsRightAnswer { get; set; }
    public int Order { get; set; }

    private Answer() : base()
    {

    }

    private Answer(string text, int questionId, bool isRightAnswer, int order)
    {
        Text = text;
        QuestionId = questionId;
        IsRightAnswer = isRightAnswer;
        Order = order;
    }

    public static Answer Create(string text, int questionId, bool isRightAnswer, int order)
    {
        return new Answer(text, questionId, isRightAnswer, order);
    }
}
