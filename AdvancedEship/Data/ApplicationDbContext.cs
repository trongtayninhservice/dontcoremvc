using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdvancedEship.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AdvancedEship.Models.Product> Products { get; set; }
        public DbSet<AdvancedEship.Models.Category> Categorys { get; set; }
        public DbSet<AdvancedEship.Models.Color> Colors { get; set; }
        public DbSet<AdvancedEship.Models.Size> Sizes { get; set; }
        public DbSet<AdvancedEship.Models.ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<AdvancedEship.Models.UserAccount> UserAccounts { get; set; }
    }
}
