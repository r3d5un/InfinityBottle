using DataAccess.Models;

namespace InfinityBottleApi.Repository.Interfaces;

public interface ICountryRepository : IRepository<Country>
{
    Task<Country?> GetAsync(string id);
}
