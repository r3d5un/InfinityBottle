using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasData(
            new Country { CountryId = "US", Name = "United States" },
            new Country { CountryId = "GB", Name = "United Kingdom" },
            new Country { CountryId = "FR", Name = "France" },
            new Country { CountryId = "JP", Name = "Japan" },
            new Country { CountryId = "CA", Name = "Canada" },
            new Country { CountryId = "IE", Name = "Ireland" },
            new Country { CountryId = "TW", Name = "Taiwan" },
            new Country { CountryId = "NO", Name = "Norway" }
        );
    }
}
