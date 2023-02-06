using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class InfinityBottleConfiguration : IEntityTypeConfiguration<InfinityBottle>
{
    public void Configure(EntityTypeBuilder<InfinityBottle> builder)
    {
        builder.HasData(
            new InfinityBottle
            {
                InfinityBottleId = 1,
                BottleName = "Sample Infinity Bottle",
                BottleSize = 70,
                NumberOfBottles = 1,
                StartDate = new DateOnly(2023, 1, 1),
                EndDate = null
            }
        );
    }
}
