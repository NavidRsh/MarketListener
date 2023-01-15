using MarketListener.Application.Features.Question.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MarketListener.Pages.Question
{
    public class AddQuestionModel : PageModel
    {
        private readonly IMediator _mediator;

        [BindProperty]
        public AddQuestionCommand AddQuestionCommand { get; set; }

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
                await _mediator.Send(AddQuestionCommand);

                return RedirectToPage("Questions");
            }


            return Page();


        }
    }
}
