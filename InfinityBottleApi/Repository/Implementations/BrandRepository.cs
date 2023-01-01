using DataAccess;
using DataAccess.Models;
using InfinityBottleApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InfinityBottleApi.Repository.Implementations;

public class BrandRepository : Repository<Brand>, IBrandRepository
{
    public BrandRepository(DatabaseContext context) : base(context) { }

    public override async Task<Brand?> GetAsync(int id)
    {
        IQueryable<Brand> query = Context.Set<Brand>().Where(brand => brand.BrandId == id);
        return await query.AsNoTracking().FirstOrDefaultAsync();
    }
}
