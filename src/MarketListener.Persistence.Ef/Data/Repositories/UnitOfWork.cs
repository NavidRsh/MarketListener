namespace MarketListener.Persistence.Ef.Data.Repositories;

using MapsterMapper;
using MarketListener.Application.Gateways.Repositories;
using MarketListener.Application.Gateways.Repositories.Answer;
using MarketListener.Application.Gateways.Repositories.Question;
using MarketListener.Application.Gateways.Repositories.User;
using MarketListener.Persistence.Ef.Data.Repositories.Answer;
using MarketListener.Persistence.Ef.Data.Repositories.Question;
using MarketListener.Persistence.Ef.Data.Repositories.User;
using MarketListener.Persistence.Ef.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Sieve.Services;
using System;
using System.Text.Json;
using System.Threading.Tasks;

public class UnitOfWork : IUnitOfWork
{

    private readonly AppDbContext _appDbContext;
    private readonly SieveProcessor _processor;
    private bool _disposed;
    private JsonSerializerOptions _jsonSerializerOptions;
    private readonly IMapper _mapper;    

    public IQuestionRepository QuestionRepository => new QuestionRepository(_appDbContext, _processor);

    public IAnswerRepository AnswerRepository => new AnswerRepository(_appDbContext, _processor);

    public IUserRepository UserRepository => new UserRepository(_appDbContext, _mapper);

    public UnitOfWork(AppDbContext appDbContext, SieveProcessor processor, IMapper mapper,
        UserManager<IdentityUserExtend> userManager)
    {
        _appDbContext = appDbContext;
        _processor = processor;
        _mapper = mapper;
    }
    
    public void SaveChanges()
    {
        _appDbContext.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await _appDbContext.SaveChangesAsync();
    }
  
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _appDbContext.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }    
}
