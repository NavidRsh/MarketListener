namespace MarketListener.Application.Features.Question.Queries;

using MarketListener.Application.Gateways.Repositories.Question;
using MarketListener.Domain.Enums.Error;
using MediatR;
using Sieve.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public sealed class ListQuestionQueryHandler : IRequestHandler<ListQuestionQuery, ListQuestionQueryDto>
{
    private readonly SieveProcessor _sieveProcessor;
    private readonly IQuestionRepository _QuestionRepository;

    public ListQuestionQueryHandler(SieveProcessor sieveProcessor, IQuestionRepository QuestionRepository)
    {
        _sieveProcessor = sieveProcessor;
        _QuestionRepository = QuestionRepository;
    }
    public async Task<ListQuestionQueryDto> Handle(ListQuestionQuery request, CancellationToken cancellationToken)
    {
        var list = await _QuestionRepository.GetQuestionList(request.SieveModel);
        var count = await _QuestionRepository.GetQuestionCount(request.SieveModel); 

        return new ListQuestionQueryDto(Status.Ok)
        {
            List = list,
            Count = count,            
            Draw = request.Draw
        };        
    }
}
