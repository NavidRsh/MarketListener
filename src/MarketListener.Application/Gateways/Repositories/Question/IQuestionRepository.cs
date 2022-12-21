namespace MarketListener.Application.Gateways.Repositories.Question;

using Domain.Entities;
using MarketListener.Application.Features.Question.Queries;
using Sieve.Models;

public interface IQuestionRepository : IGenericRepository<Question, int>
{
    Task<List<ListQuestionQueryDtoItem>> GetQuestionList(SieveModel sieveModel);
    Task<long> GetQuestionCount(SieveModel sieveModel);
}
