namespace MarketListener.Persistence.Ef.Data.Repositories.Question;

using MarketListener.Application.Features.Question.Queries;
using MarketListener.Application.Gateways.Repositories.Question;
using MarketListener.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

public sealed class QuestionRepository : EfRepository<Question, int>, IQuestionRepository
{
    private readonly SieveProcessor _processor;

    public QuestionRepository(AppDbContext dbContext, SieveProcessor processor) : base(dbContext)
    {
        _processor = processor;
    }

    public async Task<List<ListQuestionQueryDtoItem>> GetQuestionList(SieveModel sieveModel)
    {
        return await _processor.Apply(sieveModel, GetFundQueryable()).ToListAsync();
    }

    public async Task<long> GetQuestionCount(SieveModel sieveModel)
    {
        return await _processor.Apply(sieveModel, GetFundQueryable(), applyPagination: false).CountAsync();
    }

    private IQueryable<ListQuestionQueryDtoItem> GetFundQueryable()
    {
        return _dbContext.Questions
            .Select(a => new ListQuestionQueryDtoItem
            {
                Id = a.Id,
                Title = a.Title,
                IsTimeLimited = a.IsTimeLimited,
                QuestionType = a.QuestionType,
                TimeLimitSeconds= a.TimeLimitSeconds,
                Text= a.Text,
                Tags = a.Tags
            });
    }
}