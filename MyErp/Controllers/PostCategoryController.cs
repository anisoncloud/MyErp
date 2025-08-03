using Microsoft.AspNetCore.Mvc;
using MyErp.Data;
using MyErp.Models;

namespace MyErp.Controllers
{
    public class PostCategoryController : Controller
    {
        private readonly AppDbContex _context;

        public PostCategoryController(AppDbContex context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var postCategories = _context.PostCategories.ToList();
            return View(postCategories);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PostCategory postCategory)
        {
            if (ModelState.IsValid) 
            {
                _context.PostCategories.Add(postCategory);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(postCategory);
        }
    }
}
