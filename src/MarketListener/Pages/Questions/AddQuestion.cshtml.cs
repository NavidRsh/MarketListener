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
        AddQuestionVM addQuestionVM; 

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
                    Title = addQuestionVM.Title,
                    Text = addQuestionVM.Text,
                    QuestionType = addQuestionVM.QuestionType,
                    IsTimeLimited = addQuestionVM.IsTimeLimited,
                    TimeLimitSeconds = addQuestionVM.TimeLimitSeconds                    
                });

                return RedirectToPage("Questions"); 
            }


            return Page();


        }
    }
}
