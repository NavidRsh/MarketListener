namespace MarketListener.Persistence.Ef.Data.Repositories;

using MarketListener.Application.Gateways.Repositories;
using MarketListener.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EfRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
    where TKey : struct
{
    protected readonly AppDbContext _dbContext;
    private readonly DbSet<TEntity> _table;

    public EfRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _table = _dbContext.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity)
    {
        await _table.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await _table.AddRangeAsync(entities);
    }

    public void Delete(TEntity entity)
    {
        _table.Remove(entity);
    }

    public async Task<bool> DeleteAsync(TKey id)
    {
        var entity = await GetAsync(id);

        if (entity != null)
        {
            _table.Remove(entity);
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task<bool> ExistAsync(TKey id)
    {
        return await _table.AnyAsync(a => a.Id.Equals(id));
    }

    public virtual async Task<List<TEntity>> GetAllAsync()
    {
        return await _table.ToListAsync();
    }

    public virtual ValueTask<TEntity?> GetAsync(TKey id)
    {
        return _table.FindAsync(id);
    }

    public void Update(TEntity entity)
    {
        _table.Attach(entity);

        _dbContext.Entry(entity).State = EntityState.Modified;
    }
}
