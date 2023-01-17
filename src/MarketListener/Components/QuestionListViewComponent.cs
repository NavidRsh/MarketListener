using MarketListener.Application.Features.Question.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

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
            //return View(await _mediator.Send(new ListQuestionQuery()
            //{
            //    SieveModel = count == 0 ? null : new SieveModel() { 
            //        PageSize = count,
            //        Page = 1
            //    }
            //}));

            return View(); 
        }
    }

}
