using Microsoft.AspNetCore.Mvc;
using MyErp.Data;
using MyErp.Models;

namespace MyErp.Controllers
{
    public class PeopleController : Controller
    {
        private readonly AppDbContex _context;

        public PeopleController(AppDbContex context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var people = _context.Peoples.ToList();
            return View(people);
        }
        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(People people)
        {
            if (ModelState.IsValid)
            {
                _context.Peoples.Add(people);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(people);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var people = _context.Peoples.FirstOrDefault(p=>p.Id == id);
            if (people == null)
            {
                return NotFound();
            }
            return View(people);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(People people) 
        {
            var peopleToUpdate = _context.Peoples.FirstOrDefault(p=>p.Id==people.Id);
            if (peopleToUpdate == null) 
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                peopleToUpdate.Name = people.Name;
                peopleToUpdate.Description = people.Description;
              
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(people);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id) 
        {
            var people = _context.Peoples.Find(id);
            _context.Peoples.Remove(people);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
