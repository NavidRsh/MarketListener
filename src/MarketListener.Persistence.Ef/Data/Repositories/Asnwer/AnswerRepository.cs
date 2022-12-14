namespace MarketListener.Persistence.Ef.Data.Repositories.Answer;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using MarketListener.Application.Gateways.Repositories.Answer;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

public sealed class AnswerRepository : EfRepository<Answer, int>, IAnswerRepository
{
    private readonly SieveProcessor _processor;

    public AnswerRepository(AppDbContext dbContext, SieveProcessor processor) : base(dbContext)
    {
        _processor = processor;
    }   
}