using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Repository.Configurations;
using System.Reflection;

namespace NLayer.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Tek tek vermek için
            // modelBuilder.ApplyConfiguration(new ProductConfiguration());


            #region ProductFeatureSeed - Not Clean Code

            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature
            {
                Id = 1,
                ProductId = 1,
                Color = "Kırmızı",
                Height = 100,
                Width = 200,
            }, new ProductFeature
            {
                Id = 2,
                ProductId = 2,
                Color = "Mavi",
                Height = 300,
                Width = 400,
            });

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
