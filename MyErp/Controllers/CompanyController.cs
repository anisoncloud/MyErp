using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyErp.Data;
using MyErp.Models;

namespace MyErp.Controllers
{
    public class CompanyController : Controller
    {
        private readonly AppDbContex _context;

        public CompanyController(AppDbContex context)
        {
            _context = context;
        }

        // GET: Companies
        public async Task<IActionResult> Index()
        {
            var allCompanies = await _context.Companies.ToListAsync();
            return View(allCompanies);
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,CustomCompanyId,Description")] Company company)
        {
            ModelState.Remove("Users");
            if (ModelState.IsValid)
            {
                await _context.Companies.AddAsync(company);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int id, [Bind("ID,Name,CustomCompanyId,Description")] Company company)
        {
            if (id != company.ID)
            {
                return NotFound();
            }
            ModelState.Remove("Users");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Companies.Update(company);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company != null)
            {
                _context.Companies.Remove(company);
            }
            return RedirectToAction(nameof(Index));
        }
        private bool CompanyExists(int id)
        {
            return _context.Companies.Any(item => item.ID == id);

        }
    }
}
