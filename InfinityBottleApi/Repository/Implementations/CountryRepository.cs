using DataAccess;
using DataAccess.Models;
using InfinityBottleApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InfinityBottleApi.Repository.Implementations;

public class CountryRepository : Repository<Country>, ICountryRepository
{
    public CountryRepository(DatabaseContext context) : base(context) { }

    public override async Task<Country?> GetAsync(int id)
    {
        return await GetAsync(id.ToString());
    }

    public async Task<Country?> GetAsync(string id)
    {
        IQueryable<Country> query = Context
            .Set<Country>()
            .Where(country => country.CountryId == id);
        var country = await query.FirstOrDefaultAsync();
        return country;
    }
}
