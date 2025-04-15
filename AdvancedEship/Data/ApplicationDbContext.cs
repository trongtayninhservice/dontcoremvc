using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ConnectDb2.Repositories;
using ConnectDb2;
using ConnectDb2.Models;
namespace AdvancedEship.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ConnectDb2.Models.Product> Products { get; set; }
        public DbSet<ConnectDb2.Models.Category> Categorys { get; set; }
        public DbSet<ConnectDb2.Models.Color> Colors { get; set; }
        public DbSet<ConnectDb2.Models.Size> Sizes { get; set; }
        public DbSet<ConnectDb2.Models.ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ConnectDb2.Models.UserAccount> UserAccounts { get; set; }
    }
}
