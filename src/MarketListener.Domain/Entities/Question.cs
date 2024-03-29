﻿namespace MarketListener.Domain.Entities;

using MarketListener.Domain.Common;
using MarketListener.Domain.Enums;
using MarketListener.Domain.Interfaces;
using MarketListener.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

public class Question : Entity<int>, IAggregate
{
    public Question() : base()
    {

    }
    private Question(string title, string text, QuestionType questionType, List<TagLabel> tags,
        bool isTimeLimited, int timeLimitSeconds, string explanation, List<Answer> answers)
    {
        Title = title;
        Text = text;
        QuestionType = questionType;
        Tags = tags;
        IsTimeLimited = isTimeLimited;
        TimeLimitSeconds = timeLimitSeconds;
        Answers = answers;
        Explanation = explanation;
    }

    public static Question Create(string title, string text, QuestionType questionType,
        List<TagLabel> tags, bool isTimeLimited, int timeLimitSeconds, string explanation, List<Answer> answers)
    {
        return new Question(title, text, questionType, tags, isTimeLimited, timeLimitSeconds, explanation, answers);
    }

    public string Title { get; private set; } = default!;
    public string Text { get; private set; } = default!;
    public QuestionType QuestionType { get; private set; }
    public List<TagLabel> Tags { get; private set; } = default!;
    public bool IsTimeLimited { get; private set; }
    public int TimeLimitSeconds { get; private set; }
    public List<Answer> Answers { get; private set; } = new(); 
    public bool IsActive { get; private set; }
    public string Explanation { get; private set; } = default!;
    public void Update(string title, string text, QuestionType questionType, List<TagLabel> tags, bool isTimeLimited, int timeLimitSeconds, string explanation)
    {
        this.Title = title;
        this.Text = text;
        this.QuestionType = questionType;
        this.Tags = tags;
        this.IsTimeLimited = isTimeLimited;
        this.TimeLimitSeconds = timeLimitSeconds;
        this.Explanation = explanation;
    }

    public void ToggleActive()
    {
        this.IsActive = !this.IsActive;
    }
}
