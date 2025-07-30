using Microsoft.AspNetCore.Mvc;
using MyErp.Data;
using MyErp.Migrations;

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
        public IActionResult Create(MainCategory model)
        {
            if (ModelState.IsValid)
            {                
                _context.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
