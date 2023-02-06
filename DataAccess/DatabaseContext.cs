using DataAccess.Configurations;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options) { }

    public DbSet<Brand> Brands { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<History> Histories { get; set; }
    public DbSet<InfinityBottle> InfinityBottles { get; set; }
    public DbSet<Whisky> Whiskies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BrandConfiguration());
        modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new HistoryConfiguration());
        modelBuilder.ApplyConfiguration(new InfinityBottleConfiguration());
        modelBuilder.ApplyConfiguration(new WhiskyConfiguration());
    }
}
