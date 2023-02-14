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

    public async Task<Question?> GetQuestionAsync(int id)
    {
        return await _dbContext.Questions.Where(a => a.Id == id)
            .Include(a => a.Answers).FirstOrDefaultAsync(); 
    }

    public async Task<List<ListQuestionQueryDtoItem>> GetQuestionListAsync(SieveModel sieveModel)
    {
        return sieveModel != null ? await _processor.Apply(sieveModel, GetQuestionsQueryable()).ToListAsync()
            : await GetQuestionsQueryable().ToListAsync();
    }

    public async Task<long> GetQuestionCountAsync(SieveModel sieveModel)
    {
        return await _processor.Apply(sieveModel, GetQuestionsQueryable(), applyPagination: false).CountAsync();
    }

    private IQueryable<ListQuestionQueryDtoItem> GetQuestionsQueryable()
    {
        return _dbContext.Questions
            .AsNoTracking()
            .Select(a => new ListQuestionQueryDtoItem
            {
                Id = a.Id,
                Title = a.Title,
                IsTimeLimited = a.IsTimeLimited,
                QuestionType = a.QuestionType,
                TimeLimitSeconds= a.TimeLimitSeconds,
                IsActive = a.IsActive,
                Text= a.Text,
                Tags = a.Tags
            });
    }

    public void RemoveAnswers(int questionId)
    {
        _dbContext.Answers
            .RemoveRange(_dbContext.Answers.Where(a => a.QuestionId == questionId));
    }
}