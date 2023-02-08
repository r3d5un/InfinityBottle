using DataAccess;
using DataAccess.Models;
using InfinityBottleApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InfinityBottleApi.Repository.Implementations;

public class InfinityBottleRepository : Repository<InfinityBottle>, IInfinityBottleRepository
{
    public InfinityBottleRepository(DatabaseContext context) : base(context) { }

    public override async Task<InfinityBottle?> GetAsync(int id)
    {
        IQueryable<InfinityBottle> query = Context
            .Set<InfinityBottle>()
            .Where(infinityBottle => infinityBottle.InfinityBottleId == id);
        return await query.AsNoTracking().FirstOrDefaultAsync();
    }
}
