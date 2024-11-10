using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<MeatType> MeatTypes { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<ToppingProduct> ToppingsProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderedProduct> OrderedProducts { get; set; }
        public DbSet<OrderedProductTopping> OrderedProductToppings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToppingProduct>()
                .HasKey(tp => new { tp.ProductId, tp.ToppingId });

            modelBuilder.Entity<ToppingProduct>()
                .HasOne(tp => tp.Product)
                .WithMany(p => p.ToppingProducts)
                .HasForeignKey(tp => tp.ProductId);

            modelBuilder.Entity<ToppingProduct>()
                .HasOne(tp => tp.Topping)
                .WithMany(t => t.ToppingProducts)
                .HasForeignKey(tp => tp.ToppingId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
