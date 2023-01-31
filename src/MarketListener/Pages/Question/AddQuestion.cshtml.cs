using MarketListener.Application.Features.Question.Commands;
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
                    QuestionType=EditQuestionViewModel.Question.QuestionType
                });

                return RedirectToPage("Questions");
            }


            return Page();


        }
    }
}
