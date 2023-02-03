using MarketListener.Application.Features.Tag.Queries;
using MarketListener.Domain.Entities;
using MarketListener.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MarketListener.ViewModels.Question
{
    public class EditQuestionViewModel
    {
        public QuestionInfo Question { get; set; }
        public SelectList AllTags { get; set; }

        public EditQuestionViewModel()
        {
            AllTags = new SelectList(new List<ListTagQueryDtoItem>(), "Code", "Name");
        }
        public EditQuestionViewModel(IEnumerable<ListTagQueryDtoItem> alltags)
        {
            AllTags = new SelectList(alltags, "Code", "Name");
        }
        //public async static Task<EditQuestionViewModel> Create(IMediator _mediator)
        //{
        //    var tags = await _mediator.Send(new ListTagQuery());
        //    return new EditQuestionViewModel(tags.List);
        //}

        //public List<SelectListItem> AllTags { get; } = new List<SelectListItem>
        //{
        //    new SelectListItem { Value = "MX", Text = "Mexico" },
        //    new SelectListItem { Value = "CA", Text = "Canada" },
        //    new SelectListItem { Value = "US", Text = "USA"  },
        //};
    }

    public class QuestionInfo
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Text { get; set; } = default!;
        public QuestionType QuestionType { get; set; }
        public List<string> Tags { get; set; } = default!;
        public bool IsTimeLimited { get; set; }
        public int TimeLimitSeconds { get; set; }
        public int CurrentUserId { get; set; }
    }

    //public class TagInfo
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string PersianName { get; set; }
    //    public string Code { get; set; }
    //    public string Category { get; set; }
    //    public int? ParentId { get; set; }
    //    public string ParentName { get; set; }
    //}
}
