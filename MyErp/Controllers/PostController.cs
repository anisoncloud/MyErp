using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyErp.Data;
using MyErp.Models;
using MyErp.ViewModels;

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
            var vm = new PostViewModel
            {
                AllPostCategories = _context.PostCategories
                .Select(catId => new SelectListItem { Value = catId.ID.ToString(), Text = catId.Name }).ToList()
            };
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PostViewModel postViewModel)
        {
            var post = new Post
            {
                Title = postViewModel.PostName
            };
            post.PostCategoryPosts = postViewModel.SelectPostCategoryIds
                .Select(catId=> new PostCategoryPost { CategoryId = catId, PostId=catId}).ToList();
            _context.Posts.Add(post);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id) 
        {
            var post = _context.Posts
                .Include(post => post.PostCategoryPosts)
                .FirstOrDefault(post=>post.PostId==id);
            var postViewModel = new PostViewModel
            {
                Id = id,
                PostName = post.Title,
                SelectPostCategoryIds = post.PostCategoryPosts
                .Select(catId => catId.CategoryId).ToList(),
                AllPostCategories = _context.PostCategories
                .Select(p => new SelectListItem { Value = p.ID.ToString(), Text = p.Name }).ToList()
            };
            return View(postViewModel);            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PostViewModel postViewModel)
        {
            var post = _context.Posts
                .Include (post => post.PostCategoryPosts)
                .FirstOrDefault(x => x.PostId == postViewModel.Id);
            if (post==null)
            {
                return NotFound();
            }
            
                post.Title = postViewModel.PostName;
                post.PostCategoryPosts.Clear();
                post.PostCategoryPosts = postViewModel.SelectPostCategoryIds
                    .Select(postCatId=>new PostCategoryPost { CategoryId=postCatId, PostId=postCatId}).ToList();
            
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
