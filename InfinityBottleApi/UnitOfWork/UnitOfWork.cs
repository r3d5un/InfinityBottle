using DataAccess;
using InfinityBottleApi.Repository.Interfaces;
using InfinityBottleApi.Repository.Implementations;

namespace InfinityBottleApi.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseContext _context;

    public UnitOfWork(DatabaseContext context)
    {
        _context = context;
        Countries = new CountryRepository(_context);
        Companies = new CompanyRepository(_context);
    }

    public ICountryRepository Countries { get; private set; }
    public ICompanyRepository Companies { get; private set; }

    public void Dispose()
    {
        _context.DisposeAsync();
    }

    public int Complete()
    {
        return _context.SaveChanges();
    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
