using Microsoft.AspNetCore.Mvc;
using MyErp.Data;

namespace MyErp.Controllers
{
    public class CrmContactsController : Controller
    {
        private readonly AppDbContex _context;

        public CrmContactsController(AppDbContex contex)
        {
            _context = contex;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create(int id)
        {
            return View();
        }
    }
}
