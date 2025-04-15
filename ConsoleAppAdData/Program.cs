using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ConnectDb2.Repositories;
using ConnectDb2;
using ConnectDb2.Models;

class Program
{
    // dotnet run
    static async Task Main(string[] args)
    {
        // Lấy chuỗi kết nối từ ConfigurationHelper
        string connectionString = ConnectDb2.ConfigurationHelper.GetConnectionString();

        Console.WriteLine($"Connection String: {connectionString}");
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string not found.");
        }

        // Cấu hình DbContext
        var optionsBuilder = new DbContextOptionsBuilder<ConnectDb2.AppDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        // dotnet add MyApp.Data.Test package Microsoft.EntityFrameworkCore.SqlServer
        using (var context = new AppDbContext(optionsBuilder.Options))
        {
            var productRepo = new ProductRepository(context);
            var random = new Random();
            var randomNumber = random.Next(1, 100); // Tạo số ngẫu nhiên từ 1 đến 99
            // Lấy thời gian hiện tại dưới dạng chuỗi
            var currentDateTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");

            // Tạo dữ liệu test
            var newProduct = new Product
            {
                ProductName = $"Laptop ASUS {currentDateTime}",
                ProductPrice = new Random().Next(100, 500),
                ProductDescription = $"Laptop ASUS ROG Strix G15 G513QM-HN085T - {currentDateTime}",
                CategoryId = 1,
                SizeId = 1,
                ColorId = 1,
                ProductPhoto = "asus.jpg",
                IsTrandy = true,
                IsArrived = true
            };

            await productRepo.AddProductAsync(newProduct);
            Console.WriteLine("✅ Đã thêm sản phẩm mới!");

            // Lấy danh sách sản phẩm
            var products = await productRepo.GetAllProductsAsync();
            Console.WriteLine("📌 Danh sách sản phẩm:");
            foreach (var product in products)
            {
                Console.WriteLine($"- {product.ProductName}: {product.ProductPrice} - {product.ProductPhoto} ");
            }
        }
    }
}