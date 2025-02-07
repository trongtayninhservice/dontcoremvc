using Microsoft.AspNetCore.Mvc;
using AdvancedEship.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AdvancedEship.Data;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace AdvancedEship.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            //   return View();
            return View("~/Views/Login/MyLogin.cshtml");
        }
        [HttpGet]
        public IActionResult Logout()
        {
          //xóa session và di chuyển qua trang home
          HttpContext.Session.Remove("UserAccount");
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.UserAccounts
                    .FirstOrDefaultAsync(u => u.My_UserName == model.My_UserName && u.My_Password == model.My_Password);

                if (user != null)
                {
                    // Tuần tự hóa đối tượng UserAccount thành chuỗi JSON và lưu vào session
                    var userJson = JsonConvert.SerializeObject(user);

                    HttpContext.Session.SetString("UserAccount", userJson);
                    //var userJson = Context.Session.GetString("UserAccount");
                    //if (userJson != null)
                    //{
                    //    var user = JsonConvert.DeserializeObject<UserAccount>(userJson);
                    //    < li > Hello, @user.My_UserName! </ li >


                    // Lưu thông tin người dùng vào session
                    HttpContext.Session.SetString("My_UserName", user.My_UserName);
                    // Đăng nhập thành công, chuyển hướng đến trang chủ hoặc trang khác
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("My_UserName", "Invalid login attempt.");
                }
            }
            //F:\Users\DELL\source\repos\AdvancedEship\AdvancedEship\Views\Login\MyLogin.cshtml
          
            return View("~/Views/Login/MyLogin.cshtml", model);
        }
    }
}
