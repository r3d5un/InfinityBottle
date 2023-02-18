using DataAccess;
using DataAccess.Models;
using InfinityBottleApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InfinityBottleApi.Repository.Implementations;

public class HistoryRepository : Repository<History>, IHistoryRepository
{
    public HistoryRepository(DatabaseContext context)
        : base(context) { }

    public override async Task<History?> GetAsync(int id)
    {
        IQueryable<History> query = Context.Set<History>().Where(history => history.Id == id);
        return await query.AsNoTracking().FirstOrDefaultAsync();
    }
}
