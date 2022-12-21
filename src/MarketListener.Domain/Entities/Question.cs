namespace MarketListener.Domain.Entities;

using MarketListener.Domain.Common;
using MarketListener.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

public class Question : Entity<int>
{
    public Question():base()
    {

    }
    private Question(string title, string text, QuestionType questionType, List<Tag> tags, bool isTimeLimited, int timeLimitSeconds)
    {
        Title = title;
        Text = text;
        QuestionType = questionType;
        Tags = tags;
        IsTimeLimited = isTimeLimited;
        TimeLimitSeconds = timeLimitSeconds;
    }

    public static Question Create(string title, string text, QuestionType questionType, List<Tag> tags, bool isTimeLimited, int timeLimitSeconds)
    {
        return new Question(title, text, questionType, tags, isTimeLimited, timeLimitSeconds);
    }

    public string Title { get; set; } = default!;
    public string Text { get; set; } = default!;
    public QuestionType QuestionType { get; set; }
    public List<Tag> Tags { get; set; } = default!;
    public bool IsTimeLimited { get; set; }
    public int TimeLimitSeconds { get; set; }

    public void Update(string title, string text, QuestionType questionType, List<Tag> tags, bool isTimeLimited, int timeLimitSeconds)
    {
        this.Title = title;
        this.Text = text;
        this.QuestionType = questionType;
        this.Tags = tags;
        this.IsTimeLimited = isTimeLimited;
        this.TimeLimitSeconds = timeLimitSeconds;
    }
}
