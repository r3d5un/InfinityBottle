using InfinityBottleApi.Repository.Interfaces;

namespace InfinityBottleApi.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    ICountryRepository Countries { get; }
    ICompanyRepository Companies { get; }

    int Complete();
    Task<int> CompleteAsync();
}
