using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StorageApi.Models;

    public class StorageContext : DbContext
    {
    public DbSet<Product> Products { get; set; }

    public StorageContext (DbContextOptions<StorageContext> options)
            : base(options)
        {
        }

        public DbSet<StorageApi.Models.ProductDto> ProductDto { get; set; } = default!;
    override
        protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductDto>(entity =>
        {
            entity.ToTable("ProductDto");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Category).IsRequired();
            entity.Property(e => e.Shelf).IsRequired();
            entity.Property(e => e.Count).IsRequired();
            entity.Property(e => e.Description).IsRequired();
        });
        modelBuilder.Entity<ProductDto>().HasData(
            new ProductDto
            {
                Id = 1,
                Name = "Sample Product",
                Price = 9.99m,
                Category = "Sample Category",
                Shelf = "A1",
                Count = 100,
                Description = "This is a sample product description."
            },
              new ProductDto
              {
                  Id = 2,
                  Name = "Sample Product Two",
                  Price = 19.99m,
                  Category = "Sample Category",
                  Shelf = "B1",
                  Count = 100,
                  Description = "This is a sample product description."
              }
        );
    }
}
