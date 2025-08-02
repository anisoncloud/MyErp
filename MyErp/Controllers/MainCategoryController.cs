using Microsoft.AspNetCore.Mvc;
using MyErp.Data;
using MyErp.Models;
using MyErp.ViewModels;

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
        public IActionResult Create(MainCategoryViewModel mainCategoryVm)
        {
            if (ModelState.IsValid)
            {
                var mainCategory = new MainCategory()
                {
                    CategoryName = mainCategoryVm.CategoryName
                };
                            
                _context.MainCategories.Add(mainCategory);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mainCategoryVm);
        }
    }
}
