using MarketListener.Application.Features.Tag.Queries;
using MarketListener.Domain.Entities;
using MarketListener.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MarketListener.ViewModels.Question
{
    public class EditQuestionViewModel
    {
        public QuestionInfo Question { get; set; }
        [BindProperty]
        public SelectList AllTags { get; set; }

        public EditQuestionViewModel()
        {
            AllTags = new SelectList(new List<ListTagQueryDtoItem>(), "Code", "Name");
        }
        public EditQuestionViewModel(IEnumerable<ListTagQueryDtoItem> alltags)
        {
            AllTags = new SelectList(alltags, "Code", "Name");
        }        
    }

    public class QuestionInfo
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Text { get; set; } = default!;
        public QuestionType QuestionType { get; set; }
        public List<string>? Tags { get; set; } = default!;
        public bool IsTimeLimited { get; set; }
        public int TimeLimitSeconds { get; set; }
        public int CurrentUserId { get; set; }
        public string RightAnswer { get; set; }
        public string? WrongAnswer1 { get; set; }
        public string? WrongAnswer2 { get; set; }
        public string? WrongAnswer3 { get; set; }

        public string? Explanation { get; set; }
    }    
}
