using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SiteCompras.Models;

namespace SiteCompras.Data
{
    public class AppDbContext(DbContextOptions opts):IdentityDbContext<User>(opts)
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<ProductSelected> ProductSelecteds { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasOne<Cart>(a => a.Cart)
                .WithOne(a => a.User)
                .HasForeignKey<Cart>(c => c.UserId);

            base.OnModelCreating(builder);
        }
    }
}
