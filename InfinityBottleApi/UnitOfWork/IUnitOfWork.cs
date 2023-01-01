using InfinityBottleApi.Repository.Interfaces;

namespace InfinityBottleApi.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IBrandRepository Brands { get; }
    ICategoryRepository Categories { get; }
    ICountryRepository Countries { get; }
    ICompanyRepository Companies { get; }

    int Complete();
    Task<int> CompleteAsync();
}
