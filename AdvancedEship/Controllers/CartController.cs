using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdvancedEship.Data;
using AdvancedEship.Models;
using X.PagedList;
using X.PagedList.Extensions;
namespace AdvancedEship.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }
        //với mỗi sản phẩm, tôi sẽ tạo một giỏ hàng mới
        public async Task<IActionResult> AddToCart(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return Json(new { is_success = false, msg = "Product not found" });
            }

            // Giả sử bạn lưu trữ GuidId của giỏ hàng trong session
            var cartGuid = HttpContext.Session.GetString("CartGuid");
            if (string.IsNullOrEmpty(cartGuid))
            {
                cartGuid = Guid.NewGuid().ToString();
                HttpContext.Session.SetString("CartGuid", cartGuid);
            }

            var cart = await _context.ShoppingCarts
                .FirstOrDefaultAsync(c => c.GuidId.ToString() == cartGuid && c.ProductId == productId);

            if (cart == null)
            {
                cart = new ShoppingCart
                {
                    ProductId = product.ProductId,
                    Quantity = 1,
                    AddedDate = DateTime.Now,
                    GuidId = Guid.Parse(cartGuid)
                };
                _context.ShoppingCarts.Add(cart);
            }
            else
            {
                cart.Quantity++;
            }

            await _context.SaveChangesAsync();
            return Json(new { is_success = true, msg = "Added to cart successfully" });
        }

        // Phương thức để hiển thị danh sách giỏ hàng với phân trang
        [Route("my_cart.html")]
        public async Task<IActionResult> ListCart(int? page)
        {
            var cartGuid = HttpContext.Session.GetString("CartGuid");
            if (string.IsNullOrEmpty(cartGuid))
            {
                return View("~/Views/MyCart/ListCart.cshtml", new StaticPagedList<ShoppingCart>(new List<ShoppingCart>(), 1, 2, 0));
            }

            var cartItems = await _context.ShoppingCarts
                .Include(c => c.Product)
                .Where(c => c.GuidId.ToString() == cartGuid)
                .ToListAsync();

            int pageSize = 2;
            int pageNumber = page ?? 1;

            var pagedCartItems = cartItems.ToPagedList(pageNumber, pageSize);

            return View("~/Views/MyCart/ListCart.cshtml", pagedCartItems);
        }
        // Phương thức để xóa sản phẩm khỏi giỏ hàng
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int productId)
        {
            var cartGuid = HttpContext.Session.GetString("CartGuid");
            if (string.IsNullOrEmpty(cartGuid))
            {
                return Json(new { is_success = false, msg = "Cart not found" });
            }

            var cartItem = await _context.ShoppingCarts
                .FirstOrDefaultAsync(c => c.GuidId.ToString() == cartGuid && c.ProductId == productId);

            if (cartItem == null)
            {
                return Json(new { is_success = false, msg = "Product not found in cart" });
            }

            _context.ShoppingCarts.Remove(cartItem);
            await _context.SaveChangesAsync();

            return Json(new { is_success = true, msg = "Removed from cart successfully" });
        }


    }
}
