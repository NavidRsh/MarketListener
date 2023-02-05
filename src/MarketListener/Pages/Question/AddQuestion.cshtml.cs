using MarketListener.Application.Features.Question.Commands;
using MarketListener.Application.Features.Tag.Queries;
using MarketListener.Domain.Entities;
using MarketListener.ViewModels.Question;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MarketListener.Pages.Question
{
    public class AddQuestionModel : PageModel
    {
        private readonly IMediator _mediator;

        [BindProperty]
        public EditQuestionViewModel EditQuestionViewModel { get; set; }
        
        public AddQuestionModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public void OnGet()
        {
            EditQuestionViewModel = new EditQuestionViewModel(new List<ListTagQueryDtoItem>());
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(new AddQuestionCommand() { 
                    Title= EditQuestionViewModel.Question.Title,
                    Text=EditQuestionViewModel.Question.Text,
                    TimeLimitSeconds=EditQuestionViewModel.Question.TimeLimitSeconds,
                    IsTimeLimited=EditQuestionViewModel.Question.IsTimeLimited,
                    QuestionType=EditQuestionViewModel.Question.QuestionType,
                    Tags = EditQuestionViewModel.Question.Tags
                });

                return RedirectToPage("Questions");
            }


            return Page();


        }
    }
}
