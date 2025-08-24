using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyErp.Data;
using MyErp.Models;
using MyErp.ViewModels;

namespace MyErp.Controllers
{
    public class LeadController : Controller
    {
        private readonly AppDbContex _context;

        public LeadController(AppDbContex context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var leads = _context.Leads
                .Include(x=>x.CrmCompanies)
                .ToList();
            return View(leads);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var vm = new LeadViewModel
            {
                CrmCompanies = _context.CrmCompanies
                .Select(d => new SelectListItem
                {
                    Value = d.ID.ToString(),
                    Text = d.Name
                }).ToList()
            };
            
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LeadViewModel vm)
        {
            ModelState.Remove("CrmCompanies");
            if (ModelState.IsValid)
            {
                var lead = new Lead
                {
                    Name = vm.Name,
                    PhoneNumber = vm.PhoneNumber,
                    CrmCompanyId = vm.CrmCompanyId,
                    Email = vm.Email,
                    Comment = vm.Comment
                };
                _context.Leads.Add(lead);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            vm.CrmCompanies = _context.CrmCompanies
                .Select(x=> new SelectListItem
                {
                    Value=x.ID.ToString(),
                    Text = x.Name
                }).ToList();
            return View(vm);
            
        }
    }
}
