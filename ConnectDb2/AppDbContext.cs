using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using System.IO;

namespace ConnectDb2
{
    public class AppDbContext : DbContext
    {
     

        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<ConnectDb2.Models.Product> Products { get; set; }
        public DbSet<ConnectDb2.Models.Category> Categorys { get; set; }
        public DbSet<ConnectDb2.Models.Color> Colors { get; set; }
        public DbSet<ConnectDb2.Models.Size> Sizes { get; set; }
        public DbSet<ConnectDb2.Models.ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ConnectDb2.Models.UserAccount> UserAccounts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Tự động load appsettings.json trong MyApp.Data
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                string connectionString = config.GetConnectionString("DefaultConnection");
                Console.WriteLine(Directory.GetCurrentDirectory()+connectionString);
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
   
}
