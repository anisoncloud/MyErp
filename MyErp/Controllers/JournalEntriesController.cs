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
            ViewData["Accounts"] = _context.ChartOfAccounts.ToList();
            return View(new JournalEntry
            {
                Lines = new List<JournalLine> {
                new JournalLine(), new JournalLine() }
            });
            /*var accounts = _context.ChartOfAccounts.
                Select(x=> new SelectListItem
                {
                    Value = x.AccountId.ToString(),
                    Text = x.AccountName
                }).ToList();*/
            /*ViewBag.Accounts = await _context.ChartOfAccounts.ToListAsync(); 
            return View();
            */
            //return View(accounts);
        }

        /*
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
                }*/
        // POST: JournalEntries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JournalEntry entry)
        {
            var totalDebit = entry.Lines.Sum(l => l.Debit);
            var totalCredit = entry.Lines.Sum(l => l.Credit);

            if (totalDebit != totalCredit)
            {
                ModelState.AddModelError("", "Total Debit must equal Total Credit.");
            }

            if (ModelState.IsValid)
            {
                // Save entry and lines first
                _context.Add(entry);
                await _context.SaveChangesAsync();

                // 🔑 Post to ChartOfAccounts
                foreach (var line in entry.Lines)
                {
                    var account = await _context.ChartOfAccounts.FindAsync(line.AccountId);
                    if (account != null)
                    {
                        // For Assets & Expenses: Debit increases, Credit decreases
                        if (account.AccountType == "Asset" || account.AccountType == "Expense")
                        {
                            account.CurrentBalance += line.Debit;
                            account.CurrentBalance -= line.Credit;
                        }
                        // For Liabilities, Equity, Income: Credit increases, Debit decreases
                        else if (account.AccountType == "Liability" || account.AccountType == "Equity" || account.AccountType == "Income")
                        {
                            account.CurrentBalance -= line.Debit;
                            account.CurrentBalance += line.Credit;
                        }

                        _context.Update(account);
                    }
                }

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["Accounts"] = _context.ChartOfAccounts.ToList();
            return View(entry);
        }

    }
}
