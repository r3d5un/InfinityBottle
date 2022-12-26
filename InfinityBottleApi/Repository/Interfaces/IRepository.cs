using DataAccess.Models;

namespace InfinityBottleApi.Repository.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T?> GetAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();

    Task<T> AddAsync(T entity);

    void RemoveAsync(T entity);
}
