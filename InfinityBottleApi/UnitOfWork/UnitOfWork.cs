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
        Brands = new BrandRepository(_context);
        Categories = new CategoryRepository(_context);
        Countries = new CountryRepository(_context);
        Companies = new CompanyRepository(_context);
        InfinityBottles = new InfinityBottleRepository(_context);
        Whiskies = new WhiskyRepository(_context);
    }

    public IBrandRepository Brands { get; private set; }
    public ICategoryRepository Categories { get; private set; }
    public ICountryRepository Countries { get; private set; }
    public ICompanyRepository Companies { get; private set; }
    public IInfinityBottleRepository InfinityBottles { get; private set; }
    public IWhiskyRepository Whiskies { get; private set; }

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
