namespace MarketListener.Application.Features.Tag.Queries;

using MarketListener.Application.Gateways.Repositories.Tag;
using MarketListener.Domain.Enums.Error;
using MediatR;
using Sieve.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public sealed class ListTagQueryHandler : IRequestHandler<ListTagQuery, ListTagQueryDto>
{
    private readonly SieveProcessor _sieveProcessor;
    private readonly ITagRepository _TagRepository;

    public ListTagQueryHandler(SieveProcessor sieveProcessor, ITagRepository TagRepository)
    {
        _sieveProcessor = sieveProcessor;
        _TagRepository = TagRepository;
    }
    public async Task<ListTagQueryDto> Handle(ListTagQuery request, CancellationToken cancellationToken)
    {
        var list = await _TagRepository.GetTagList(request.SieveModel);
        var count = await _TagRepository.GetTagCount(request.SieveModel); 

        return new ListTagQueryDto(Status.Ok)
        {
            List = list,
            Count = count
        };        
    }
}
