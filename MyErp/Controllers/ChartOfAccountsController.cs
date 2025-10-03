using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyErp.Data;
using MyErp.Models;

namespace MyErp.Controllers
{
    public class ChartOfAccountsController : Controller
    {
        private readonly AppDbContex _context;

        public ChartOfAccountsController(AppDbContex context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var accounts = await _context.ChartOfAccounts
                .Include(x => x.ParentAccount)
                .ToListAsync();
            return View(accounts);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["ParentAccounts"] = _context.ChartOfAccounts.ToList();
            return View();
        }
        // POST: ChartOfAccounts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ChartOfAccount account)
        {
            if (ModelState.IsValid)
            {
                _context.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }
        // GET: ChartOfAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var account = await _context.ChartOfAccounts.FindAsync(id);
            if (account == null) return NotFound();

            ViewData["ParentAccounts"] = _context.ChartOfAccounts.Where(a => a.AccountId != id).ToList();
            return View(account);
        }
        // POST: ChartOfAccounts/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ChartOfAccount account)
        {
            if (id != account.AccountId) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(account);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: ChartOfAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var account = await _context.ChartOfAccounts.FindAsync(id);
            if (account == null) return NotFound();

            return View(account);
        }

        // POST: ChartOfAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var account = await _context.ChartOfAccounts.FindAsync(id);
            if (account != null)
            {
                _context.ChartOfAccounts.Remove(account);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
