using Microsoft.EntityFrameworkCore;
using OrderManagementAPI.Domain.Entities;

namespace OrderManagementAPI.Infrastructure.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.Property(e => e.Status).IsRequired();
                entity.HasMany(e => e.Items)
                    .WithOne(i => i.Order)
                    .HasForeignKey(i => i.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ProductName).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Price).HasPrecision(10, 2);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Price).HasPrecision(10, 2);
            });

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Notebook Dell", Price = 3500.00m, Quantity = 10 },
                new Product { Id = 2, Name = "Monitor LG 24\"", Price = 800.00m, Quantity = 15 },
                new Product { Id = 3, Name = "Teclado Mecânico", Price = 450.00m, Quantity = 20 }
            );
        }
    }
}
