using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class HistoryConfiguration : IEntityTypeConfiguration<History>
{
    public void Configure(EntityTypeBuilder<History> builder)
    {
        builder.HasData(
            new History
            {
                Id = 1,
                Date = new DateOnly(2023, 1, 1),
                InfinityBottleId = 1,
                WhiskyId = 1,
                Amount = 4
            },
            new History
            {
                Id = 2,
                Date = new DateOnly(2023, 1, 2),
                InfinityBottleId = 1,
                WhiskyId = 2,
                Amount = 4
            },
            new History
            {
                Id = 3,
                Date = new DateOnly(2023, 1, 3),
                InfinityBottleId = 1,
                WhiskyId = 3,
                Amount = 4
            }
        );
    }
}
