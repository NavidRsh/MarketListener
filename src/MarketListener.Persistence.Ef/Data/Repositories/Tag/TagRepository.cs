namespace MarketListener.Persistence.Ef.Data.Repositories.Tag;

using MarketListener.Application.Features.Tag.Queries;
using MarketListener.Application.Gateways.Repositories.Tag;
using MarketListener.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

public sealed class TagRepository : EfRepository<Tag, int>, ITagRepository
{
    private readonly SieveProcessor _processor;

    public TagRepository(AppDbContext dbContext, SieveProcessor processor) : base(dbContext)
    {
        _processor = processor;
    }

    public async Task<List<ListTagQueryDtoItem>> GetTagList(SieveModel sieveModel)
    {
        return sieveModel != null ? await _processor.Apply(sieveModel, GetTagsQueryable()).ToListAsync()
            : await GetTagsQueryable().ToListAsync();
    }

    public async Task<long> GetTagCount(SieveModel sieveModel)
    {
        return await _processor.Apply(sieveModel, GetTagsQueryable(), applyPagination: false).CountAsync();
    }

    private IQueryable<ListTagQueryDtoItem> GetTagsQueryable()
    {
        return _dbContext.Tags
            .AsNoTracking()
            .Select(a => new ListTagQueryDtoItem
            {
                Id = a.Id,
                Name = a.Name,
                PersianName = a.PersianName,
                Code = a.Code,
                Category = a.Category,
                ParentId = a.ParentId,
                ParentName = a.Parent != null ? a.Parent.Name : null
            });
    }
}