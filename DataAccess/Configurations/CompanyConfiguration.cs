using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasData(
            new Company
            {
                CompanyId = 1,
                Name = "Beam Suntory",
                Address = "222 W Merchandise Mart Plz Ste 1600",
                City = "Chicago",
                PostalCode = "60654",
                State = "Illinois",
                CountryId = "US"
            },
            new Company
            {
                CompanyId = 2,
                Name = "Balcones Distilling",
                Address = "225 S 11th St, Waco",
                City = "Waco, Texas",
                PostalCode = "76701",
                State = "Texas",
                CountryId = "US"
            },
            new Company
            {
                CompanyId = 3,
                Name = "LVMH",
                Address = "22 Avenue Montaigne",
                City = "Paris",
                PostalCode = "75008",
                State = null,
                CountryId = "FR"
            }
        );
    }
}
