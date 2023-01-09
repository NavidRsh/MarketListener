using MarketListener.Application.Features.Question.Commands;
using MarketListener.ViewModels.Question;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MarketListener.Pages.Questions
{
    public class AddQuestionModel : PageModel
    {
        private readonly IMediator _mediator;

        [BindProperty]
        public AddQuestionVM AddQuestionVM { get; set; }

        public AddQuestionModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                await _mediator.Send(new AddQuestionCommand()
                {
                    Title = AddQuestionVM.Title,
                    Text = AddQuestionVM.Text,
                    QuestionType = AddQuestionVM.QuestionType,
                    IsTimeLimited = AddQuestionVM.IsTimeLimited,
                    TimeLimitSeconds = AddQuestionVM.TimeLimitSeconds                    
                });

                return RedirectToPage("Questions"); 
            }


            return Page();


        }
    }
}
