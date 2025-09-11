using Microsoft.AspNetCore.Mvc;
using MyErp.Data;
using MyErp.Models;

namespace MyErp.Controllers
{
    public class LeaveAllocationController : Controller
    {
        private readonly AppDbContex _context;

        public LeaveAllocationController(AppDbContex context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LeaveAllocation model)
        {
            return View();
        }
    }
}
