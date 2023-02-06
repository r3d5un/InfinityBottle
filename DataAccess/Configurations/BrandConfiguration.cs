using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.HasData(
            new Brand
            {
                BrandId = 1,
                Name = "Laphroaig",
                CompanyId = 1
            },
            new Brand
            {
                BrandId = 2,
                Name = "Ardmore",
                CompanyId = 3
            },
            new Brand
            {
                BrandId = 3,
                Name = "Auchentoshan",
                CompanyId = 3
            },
            new Brand
            {
                BrandId = 4,
                Name = "Bowmore",
                CompanyId = 3
            },
            new Brand
            {
                BrandId = 5,
                Name = "Glen Garioch",
                CompanyId = 3
            },
            new Brand
            {
                BrandId = 6,
                Name = "McClelland",
                CompanyId = 3
            },
            new Brand
            {
                BrandId = 7,
                Name = "Connemara",
                CompanyId = 3
            },
            new Brand
            {
                BrandId = 8,
                Name = "Balcones",
                CompanyId = 2
            },
            new Brand
            {
                BrandId = 9,
                Name = "Ardbeg",
                CompanyId = 3
            }
        );
    }
}
