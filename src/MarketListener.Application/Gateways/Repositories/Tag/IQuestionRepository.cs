namespace MarketListener.Application.Gateways.Repositories.Tag;

using Domain.Entities;
using MarketListener.Application.Features.Tag.Queries;
using Sieve.Models;

public interface ITagRepository : IGenericRepository<Tag, int>
{
    Task<List<ListTagQueryDtoItem>> GetTagList(SieveModel sieveModel);
    Task<long> GetTagCount(SieveModel sieveModel);
}
