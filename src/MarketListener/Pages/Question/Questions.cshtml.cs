using MarketListener.Application.Features.Question.Commands;
using MarketListener.Application.Features.Question.Queries;
using MarketListener.Application.Features.Tag.Queries;
using MarketListener.ViewModels.Question;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MarketListener.Pages.Question
{
    public class QuestionsModel : PageModel
    {
        private readonly IMediator _mediator;

        public QuestionsModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnGetToggleActive(int id)
        {
            var result = await _mediator.Send(new ToggleActiveCommand() { Id = id }); 

            return new JsonResult(result);
        }

    }
}
