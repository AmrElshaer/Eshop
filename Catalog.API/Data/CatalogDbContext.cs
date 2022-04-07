using Catalog.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Data
{
    public class CatalogDbContext:DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options):base(options)
        {
           
        }

        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogDbContext).Assembly);
        }
    }
}
