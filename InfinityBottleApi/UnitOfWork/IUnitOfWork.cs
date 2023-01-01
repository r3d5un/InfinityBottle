using InfinityBottleApi.Repository.Interfaces;

namespace InfinityBottleApi.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    ICategoryRepository Categories { get; }
    ICountryRepository Countries { get; }
    ICompanyRepository Companies { get; }

    int Complete();
    Task<int> CompleteAsync();
}
