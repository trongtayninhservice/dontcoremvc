using AdvancedEship.Data;
using Microsoft.AspNetCore.Mvc;
namespace AdvancedEship.Components
{


    public class Trandy : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public Trandy(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var myData = _context.Products.Where(p => p.IsTrandy == true).ToList();
           // var myData = _context.Products.ToList();
            //show count in log
            var count = myData.Count();
            //log the count
            Console.WriteLine($"Count of trendy productscc: {count}");
            return View(model: myData);
        }
    }
}
