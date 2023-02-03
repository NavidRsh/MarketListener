using MarketListener.Application.Features.Question.Commands;
using MarketListener.Application.Features.Question.Queries;
using MarketListener.Application.Features.Tag.Queries;
using MarketListener.Domain.Entities;
using MarketListener.ViewModels.Question;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MarketListener.Pages.Question
{
    public class EditQuestionModel : PageModel
    {
        [FromRoute]
        public int Id { get; set; }
        [BindProperty]
        public EditQuestionViewModel EditQuestionViewModel { get; set; } 

        private readonly IMediator _mediator;
        public EditQuestionModel(IMediator mediator)
        {
            _mediator = mediator;

            //var tags = _mediator.Send(new ListTagQuery()).Result;
            
        }
        public async Task OnGet()
        {
            var question = await _mediator.Send(new GetQuestionQuery() { Id = Id });
            var tags = await _mediator.Send(new ListTagQuery());            
            EditQuestionViewModel = new EditQuestionViewModel(tags.List);

            EditQuestionViewModel.Question = new QuestionInfo()
            {
                Id = question.Id,
                IsTimeLimited = question.IsTimeLimited,
                QuestionType = question.QuestionType,
                Tags = question.Tags,
                Text = question.Text,
                TimeLimitSeconds = question.TimeLimitSeconds,
                Title = question.Title
            };
            //Tags = tags.List.Select(a => new TagInfo()
            //{
            //    Id = a.Id,
            //    Name = a.Name,
            //    PersianName = a.PersianName,
            //    Code = a.Code,
            //    ParentId = a.ParentId,
            //    Category = a.Category,
            //    ParentName = a.ParentName
            //}).ToList(),
            //AllTags = new SelectList(tags.List, "Code", "Name")


        }

        public async Task<IActionResult> OnPostEdit()
        {
            if (!ModelState.IsValid) { return Page(); }

            await _mediator.Send(new UpdateQuestionCommand()
            {
                Id = EditQuestionViewModel.Question.Id,
                QuestionType = EditQuestionViewModel.Question.QuestionType,
                IsTimeLimited = EditQuestionViewModel.Question.IsTimeLimited,
                Text = EditQuestionViewModel.Question.Text,
                TimeLimitSeconds = EditQuestionViewModel.Question.TimeLimitSeconds,
                Title = EditQuestionViewModel.Question.Title,
                Tags = EditQuestionViewModel.Question.Tags
            });

            return RedirectToPage("Questions");
        }

        public async Task<IActionResult> OnPostDelete()
        {
            await _mediator.Send(new DeleteQuestionCommand() { Id = Id });

            return RedirectToPage("Questions");

        }
    }
}
