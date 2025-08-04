using Microsoft.AspNetCore.Mvc;
using MyErp.Data;

namespace MyErp.Controllers
{
    public class PostController : Controller
    {
        private readonly AppDbContex _context;

        public PostController(AppDbContex context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var posts = _context.Posts.ToList();
            return View(posts);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
