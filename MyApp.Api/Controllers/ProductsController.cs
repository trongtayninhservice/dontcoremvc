using Microsoft.AspNetCore.Mvc;
using ConnectDb2.Models;
using ConnectDb2.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConnectDb2;
using Microsoft.AspNetCore.Authorization;
namespace MyApp.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductRepository _productRepository;

        // Khởi tạo AppDbContext thuộc ConnectDb2 được khởi tạo tại Program.cs
        public ProductsController(AppDbContext context)
        {
            _productRepository = new ProductRepository(context);
        }

        // Lấy danh sách sản phẩm
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return Ok(products);
        }

        // Thêm sản phẩm mới
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            await _productRepository.AddProductAsync(product);
            return CreatedAtAction(nameof(GetProducts), new { ProductId = product.ProductId }, product);
        }
    }
}
