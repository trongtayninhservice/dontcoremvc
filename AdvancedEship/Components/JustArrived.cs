using AdvancedEship.Data;
using Microsoft.AspNetCore.Mvc;
namespace AdvancedEship.Components
{


    public class JustArrived : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public JustArrived(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var t = 1;
            t = t + 1;
            t = t + 50;
            return View(_context.Products.Where(p=>p.IsArrived==true).ToList());
        }
    }
}
