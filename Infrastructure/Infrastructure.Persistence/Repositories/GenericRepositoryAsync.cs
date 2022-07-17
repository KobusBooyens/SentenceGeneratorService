using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
  public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
  {
    private readonly ApplicationDbContext _dbContext;

    public GenericRepositoryAsync(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<T?> GetByIdAsync(int id)
    {
      return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<List<T>> GetAllAsync()
    {
      return await _dbContext
        .Set<T>()
        .ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
      await _dbContext.Set<T>().AddAsync(entity);
      await _dbContext.SaveChangesAsync();
      return entity;
    }

    public async Task AddRangeAsync(T[] entities)
    {
      await _dbContext.Set<T>().AddRangeAsync(entities);
      await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
      await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateRangeAsync(T[] entities)
    {
      await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
      _dbContext.Set<T>().Remove(entity);
      await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteRangeAsync(List<T> entity)
    {
      _dbContext.Set<T>().RemoveRange(entity);
      await _dbContext.SaveChangesAsync();
    }
  }
}
