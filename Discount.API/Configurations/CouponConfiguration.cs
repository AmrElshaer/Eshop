using Discount.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Discount.API.Configurations
{
    public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.Property(a => a.ProductName).HasColumnType("varchar(50)");
            builder.HasData(new Coupon {Id=1, ProductName= "IPhone X",Description= "IPhone Discount",Amount=150 },
                new Coupon {Id=2, ProductName = "Samsung 10", Description = "Samsung Discount", Amount = 100 });
        }
    }
}
