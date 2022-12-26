using InfinityBottleApi.Repository.Interfaces;

namespace InfinityBottleApi.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    ICountryRepository Countries { get; }

    int Complete();
    Task<int> CompleteAsync();
}
