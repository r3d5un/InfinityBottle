using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class WhiskyConfiguration : IEntityTypeConfiguration<Whisky>
{
    public void Configure(EntityTypeBuilder<Whisky> builder)
    {
        builder.HasData(
            new Whisky
            {
                WhiskyId = 1,
                Name = "Laphroaig 10 Year Old",
                BrandId = 1,
                CategoryId = 1,
                Age = 10,
                ABV = 40,
                Price = null
            },
            new Whisky
            {
                WhiskyId = 2,
                Name = "Ardbeg 10 Year Old",
                BrandId = 9,
                CategoryId = 1,
                Age = 10,
                ABV = 46,
                Price = null
            },
            new Whisky
            {
                WhiskyId = 3,
                Name = "Connemara Peated Single Malt",
                BrandId = 7,
                CategoryId = 8,
                Age = 12,
                ABV = 40,
                Price = null
            }
        );
    }
}
