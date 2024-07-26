using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SiteCompras.Models;

namespace SiteCompras.Data
{
    public class AppDbContext(DbContextOptions opts):IdentityDbContext<User>(opts)
    {
        public DbSet<Product> Products { get; set; }
    }
}
