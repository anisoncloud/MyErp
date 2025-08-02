using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyErp.Data;
using MyErp.Models;
using MyErp.ViewModels;

namespace MyErp.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContex _context;

        public ProductController(AppDbContex context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var vm = new ProductViewModel()
            {
                AllMainCategories = _context.MainCategories
                .Select(c => new SelectListItem { Value = c.ID.ToString(), Text = c.CategoryName }).ToList()
            };
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel vm)
        {
            var product = new Product
            {
                Name = vm.Name,
                Description = vm.Description??""
            };
            product.ProductMainCategories = vm.SelectedMainCategoryIds
                .Select(catId => new ProductMainCategory { CategoryId = catId }).ToList();
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");            
        }

    }
}
