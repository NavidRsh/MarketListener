namespace MarketListener.Application.Gateways.Repositories;

using MarketListener.Domain.Interfaces;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IGenericRepository<TEntity, TKey> 
    where TEntity : IEntity<TKey>
    where TKey : struct
{
    ValueTask<TEntity?> GetAsync(TKey id);

    Task<List<TEntity>> GetAllAsync();

    Task AddAsync(TEntity entity);

    Task AddRangeAsync(IEnumerable<TEntity> entities);

    void Update(TEntity entity);

    void Delete(TEntity entity);

    Task<bool> DeleteAsync(TKey id);

    Task<bool> ExistAsync(TKey id);
}
