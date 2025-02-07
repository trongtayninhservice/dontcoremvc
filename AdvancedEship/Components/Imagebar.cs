using AdvancedEship.Data;
using Microsoft.AspNetCore.Mvc;
namespace AdvancedEship.Components
{


    public class Imagebar : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public Imagebar(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            return View("index",_context.Categorys.ToList());
        }
    }
}
