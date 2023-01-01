using DataAccess;
using DataAccess.Models;
using InfinityBottleApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InfinityBottleApi.Repository.Implementations;

public class CompanyRepository : Repository<Company>, ICompanyRepository
{
    public CompanyRepository(DatabaseContext context) : base(context) { }

    public override async Task<Company?> GetAsync(int id)
    {
        IQueryable<Company> query = Context
            .Set<Company>()
            .Where(company => company.CompanyId == id);
        return await query.AsNoTracking().FirstOrDefaultAsync();
    }
}
