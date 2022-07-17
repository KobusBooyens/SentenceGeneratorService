using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
  public interface IGenericRepositoryAsync<T> where T : class
  {
    Task<T?> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task AddRangeAsync(T[] entities);
    Task UpdateAsync(T entity);
    Task UpdateRangeAsync(T[] entities);
    Task DeleteAsync(T entity);
  }
}