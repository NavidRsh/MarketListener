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

            var allTags = await _mediator.Send(new ListTagQuery());            
            EditQuestionViewModel = new EditQuestionViewModel(allTags.List);

            var rightAnswer = question.Answers.Where(a => a.IsRightAnswer).FirstOrDefault();
            var wrongAnswers = question.Answers.Where(a => !a.IsRightAnswer).ToList(); 

            EditQuestionViewModel.Question = new QuestionInfo()
            {
                Id = question.Id,
                IsTimeLimited = question.IsTimeLimited,
                QuestionType = question.QuestionType,
                Tags = question.Tags,
                Text = question.Text,
                TimeLimitSeconds = question.TimeLimitSeconds,
                Title = question.Title,
                RightAnswer = rightAnswer?.Text,
                WrongAnswer1 = wrongAnswers.Count > 0 ? wrongAnswers[0].Text : "",
                WrongAnswer2 = wrongAnswers.Count > 1 ? wrongAnswers[1].Text : "",
                WrongAnswer3 = wrongAnswers.Count > 2 ? wrongAnswers[2].Text : "",
            };
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
                Tags = EditQuestionViewModel.Question.Tags,
                Answers = new List<UpdateQuestionAnswerDto>() {
                    new UpdateQuestionAnswerDto(){
                        IsRightAnswer = true, 
                        Order = 1,
                        Text = EditQuestionViewModel.Question.RightAnswer
                    },
                    new UpdateQuestionAnswerDto(){
                        IsRightAnswer = false,
                        Order = 2,
                        Text = EditQuestionViewModel.Question.WrongAnswer1
                    },
                    new UpdateQuestionAnswerDto(){
                        IsRightAnswer = false,
                        Order = 3,
                        Text = EditQuestionViewModel.Question.WrongAnswer2
                    },
                    new UpdateQuestionAnswerDto(){
                        IsRightAnswer = false,
                        Order = 4,
                        Text = EditQuestionViewModel.Question.WrongAnswer3
                    }
                }
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
