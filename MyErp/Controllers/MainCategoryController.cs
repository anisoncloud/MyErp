using Microsoft.AspNetCore.Mvc;
using MyErp.Data;
using MyErp.Models;

namespace MyErp.Controllers
{
    public class MainCategoryController : Controller
    {
        private readonly AppDbContex _context;

        public MainCategoryController(AppDbContex context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var mainCategory = _context.MainCategories.ToList();
            return View(mainCategory);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MainCategory mainCategory)
        {
            if (ModelState.IsValid)
            {                
                await _context.MainCategories.AddAsync(mainCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mainCategory);
        }
    }
}
