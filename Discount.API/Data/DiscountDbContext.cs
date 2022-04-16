using Discount.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Discount.API.Data
{
    public class DiscountDbContext : DbContext
    {
        public DiscountDbContext(DbContextOptions<DiscountDbContext> options) : base(options)
        {

        }

        public DbSet<Coupon> Coupons { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DiscountDbContext).Assembly);
        }
    }
}
