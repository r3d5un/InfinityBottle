using DataAccess;
using DataAccess.Models;
using InfinityBottleApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InfinityBottleApi.Repository.Implementations;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(DatabaseContext context) : base(context) { }

    public override async Task<Category?> GetAsync(int id)
    {
        IQueryable<Category> query = Context
            .Set<Category>()
            .Where(category => category.CategoryId == id);
        return await query.AsNoTracking().FirstOrDefaultAsync();
    }
}
