using Microsoft.AspNetCore.Mvc;
using MyErp.Data;
using MyErp.Models;

namespace MyErp.Controllers
{
    public class PublicHolidaysController : Controller
    {
        private readonly AppDbContex _context;

        public PublicHolidaysController(AppDbContex context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var holidays = _context.PublicHolidays.ToList();
            return View(holidays);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PublicHolidays model)
        {
            if (!ModelState.IsValid) 
            {
                return View(model);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
