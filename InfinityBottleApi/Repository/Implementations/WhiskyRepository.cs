using DataAccess;
using DataAccess.Models;
using InfinityBottleApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InfinityBottleApi.Repository.Implementations;

public class WhiskyRepository : Repository<Whisky>, IWhiskyRepository
{
    public WhiskyRepository(DatabaseContext context) : base(context) { }

    public override async Task<Whisky?> GetAsync(int id)
    {
        IQueryable<Whisky> query = Context.Set<Whisky>().Where(category => category.WhiskyId == id);
        return await query.AsNoTracking().FirstOrDefaultAsync();
    }
}
