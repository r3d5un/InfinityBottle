using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasData(
            new Category
            {
                CategoryId = 1,
                Name = "Scotch",
                Region = "Islay",
                SubCategory = "Islay Single Malt"
            },
            new Category
            {
                CategoryId = 2,
                Name = "Scotch",
                Region = "Highland",
                SubCategory = "Highland Single Malt"
            },
            new Category
            {
                CategoryId = 3,
                Name = "Scotch",
                Region = "Lowland",
                SubCategory = "Lowland Single Malt"
            },
            new Category
            {
                CategoryId = 5,
                Name = "Scotch",
                Region = "Strathspey",
                SubCategory = "Speyside Single Malt"
            },
            new Category
            {
                CategoryId = 6,
                Name = "Bourbon",
                Region = "America",
                SubCategory = "Kentucky Straight Bourbon Whiskey"
            },
            new Category
            {
                CategoryId = 7,
                Name = "Rye",
                Region = "America",
                SubCategory = "Kentucky Straight Rye Whiskey"
            },
            new Category
            {
                CategoryId = 8,
                Name = "Irish",
                Region = "Ireland",
                SubCategory = "Irish Single Malt"
            }
        );
    }
}
