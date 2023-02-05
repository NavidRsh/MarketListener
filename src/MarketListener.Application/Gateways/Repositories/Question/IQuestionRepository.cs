namespace MarketListener.Application.Gateways.Repositories.Question;

using Domain.Entities;
using MarketListener.Application.Features.Question.Queries;
using Sieve.Models;

public interface IQuestionRepository : IGenericRepository<Question, int>
{
    Task<Question?> GetQuestionAsync(int id);
    Task<List<ListQuestionQueryDtoItem>> GetQuestionListAsync(SieveModel sieveModel);
    Task<long> GetQuestionCountAsync(SieveModel sieveModel);
    void RemoveAnswers(int questionId);
}
