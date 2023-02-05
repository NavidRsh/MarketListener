namespace MarketListener.Application.Gateways.Repositories;

using MarketListener.Application.Gateways.Repositories.Answer;
using MarketListener.Application.Gateways.Repositories.Question;
using System.Threading.Tasks;

public interface IUnitOfWork
{
    IQuestionRepository QuestionRepository { get; }

    void SaveChanges();

    Task SaveChangesAsync();
}
