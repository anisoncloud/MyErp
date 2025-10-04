using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyErp.Data;
using MyErp.Models;

namespace MyErp.Controllers
{
    public class JournalEntriesController : Controller
    {
        private readonly AppDbContex _context;

        public JournalEntriesController(AppDbContex context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var entries = await _context.JournalEntries
                .Include(j => j.Lines)
                .ThenInclude(l => l.Account)
                .ToListAsync();

            return View(entries);
        }

        // GET: JournalEntries/Create
        public async Task<IActionResult> Create()
        {
            /*ViewData["Accounts"] = _context.ChartOfAccounts.ToList();
            return View(new JournalEntry
            {
                Lines = new List<JournalLine> {
                new JournalLine(), new JournalLine() }
            });*/
            var accounts = _context.ChartOfAccounts.
                Select(x=> new SelectListItem
                {
                    Value = x.AccountId.ToString(),
                    Text = x.AccountName
                }).ToList();
            /*ViewBag.Accounts = await _context.ChartOfAccounts.ToListAsync(); 
            return View();
            */
            return View(accounts);
        }

        // POST: JournalEntries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JournalEntry entry)
        {
            // Validation: total debit == total credit
            var totalDebit = entry.Lines.Sum(l => l.Debit);
            var totalCredit = entry.Lines.Sum(l => l.Credit);

            if (totalDebit != totalCredit)
            {
                ModelState.AddModelError("", "Total Debit must equal Total Credit.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(entry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Accounts"] = _context.ChartOfAccounts.ToList();
            return View(entry);
        }
    }
}
