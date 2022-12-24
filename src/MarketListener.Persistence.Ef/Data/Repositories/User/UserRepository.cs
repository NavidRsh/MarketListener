namespace MarketListener.Persistence.Ef.Data.Repositories.User;

using MapsterMapper;
using MarketListener.Application.Gateways.Repositories.User;
using MarketListener.Domain.Entities;
using MarketListener.Persistence.Ef.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UserRepository : IUserRepository
{
    private readonly IMapper _mapper;

    public UserRepository(AppDbContext dbContext, IMapper mapper)
    {        
        _mapper = mapper;
    }    

    public Task AddAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task AddRangeAsync(IEnumerable<User> entities)
    {
        throw new NotImplementedException();
    }

    public void Delete(User entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<User?> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(User entity)
    {
        throw new NotImplementedException();
    }
}
