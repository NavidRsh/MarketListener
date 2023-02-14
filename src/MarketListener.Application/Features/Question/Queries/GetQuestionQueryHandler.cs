namespace MarketListener.Application.Features.Question.Queries;

using MarketListener.Application.Gateways.Repositories.Question;
using MarketListener.Domain.Enums.Error;
using MediatR;
using Sieve.Services;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

public sealed class GetQuestionQueryHandler : IRequestHandler<GetQuestionQuery, GetQuestionQueryDto>
{
    private readonly SieveProcessor _sieveProcessor;
    private readonly IQuestionRepository _QuestionRepository;

    public GetQuestionQueryHandler(SieveProcessor sieveProcessor, IQuestionRepository QuestionRepository)
    {
        _sieveProcessor = sieveProcessor;
        _QuestionRepository = QuestionRepository;
    }
    public async Task<GetQuestionQueryDto> Handle(GetQuestionQuery request, CancellationToken cancellationToken)
    {
        var item = await _QuestionRepository.GetQuestionAsync(request.Id);
        if(item == null)
        {
            return new GetQuestionQueryDto(Status.NotFound); 
        }

        return new GetQuestionQueryDto(Status.Ok)
        {
            Id = item.Id,
            IsTimeLimited = item.IsTimeLimited,
            QuestionType = item.QuestionType,
            Tags = item.Tags != null ? item.Tags.Select(a => a.Code).ToList() : new List<string>(),
            Text = item.Text,
            TimeLimitSeconds = item.TimeLimitSeconds,
            Title = item.Title,
            Explanation = item.Explanation,
            Answers = item.Answers.Select(a => new QuestionAnswerDtoItem() { 
                IsRightAnswer = a.IsRightAnswer,
                Order = a.Order,
                Text = a.Text
            }).ToList()
        };
    }
}
