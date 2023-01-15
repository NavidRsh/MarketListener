using MarketListener.Application.Features.Question.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MarketListener.Components
{
    public class QuestionListViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;
        public QuestionListViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _mediator.Send(new ListQuestionQuery()
            {
                SieveModel = null
            }));
        }
    }

}
