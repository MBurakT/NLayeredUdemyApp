using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;

namespace NLayer.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product
            {
                Id = 1,
                CategoryId = 1,
                Name = "Kurşun Kalem",
                Price = 100,
                Stock = 30,
                CreatedDate = DateTime.Now,
            }, new Product()
            {
                Id = 2,
                CategoryId = 1,
                Name = "Pilot Kalem",
                Price = 200,
                Stock = 20,
                CreatedDate = DateTime.Now,
            }, new Product()
            {
                Id = 3,
                CategoryId = 1,
                Name = "Dolma Kalem",
                Price = 500,
                Stock = 5,
                CreatedDate = DateTime.Now,
            }, new Product()
            {
                Id = 4,
                CategoryId = 2,
                Name = "Neptün",
                Price = 100,
                Stock = 50,
                CreatedDate = DateTime.Now,
            }, new Product()
            {
                Id = 5,
                CategoryId = 3,
                Name = "Hammurabi",
                Price = 60,
                Stock = 60,
                CreatedDate = DateTime.Now,
            });
        }
    }
}
