using DataAccess;
using InfinityBottleApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InfinityBottleApi.Repository.Implementations;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly DatabaseContext Context;

    public Repository(DatabaseContext context)
    {
        Context = context;
    }

    public virtual async Task<T?> GetAsync(int id)
    {
        IQueryable<T?> query = Context.Set<T>();
        return await query.FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        IQueryable<T> query = Context.Set<T>();
        IEnumerable<T> result = await query.AsNoTracking().ToListAsync();
        return result;
    }

    public async Task<T> AddAsync(T entity)
    {
        await Context.Set<T>().AddAsync(entity);
        return entity;
    }

    public void RemoveAsync(T entity)
    {
        Context.Set<T>().Remove(entity);
    }
}
