namespace MarketListener.Persistence.Ef.Data.Repositories.Question;

using MarketListener.Application.Gateways.Repositories.Question;
using MarketListener.Domain.Entities;
using Sieve.Services;

public sealed class QuestionRepository : EfRepository<Question, int>, IQuestionRepository
{
    private readonly SieveProcessor _processor;

    public QuestionRepository(AppDbContext dbContext, SieveProcessor processor) : base(dbContext)
    {
        _processor = processor;
    }   
}