using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyErp.Data;
using MyErp.Models;
using MyErp.ViewModels;

namespace MyErp.Controllers
{
    public class DomainController : Controller
    {
        private readonly AppDbContex _context;

        public DomainController(AppDbContex context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var domains = _context.Domains.ToList();
            return View(domains);
        }        

        [HttpGet]
        public IActionResult Create()
        {
            var vm = new DomainViewModel
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
        public IActionResult Create(DomainViewModel vm)
        {
            var domain = new Domain
            {
                DomainName = vm.DomainName,
                RegistarDate = vm.RegistarDate,
                DomainRegistrant = vm.DomainRegistrant,
                CompanyId = vm.CompanyId,
                ForYear = vm.ForYear,
                ExpireDate = vm.ExpireDate,
                Hosting = vm.Hosting,
                IpAddress = vm.IpAddress,
                Analytics = vm.Analytics,
                Dns = vm.Dns,
                Comments = vm.Comments
            };
            _context.Domains.Add(domain);
            _context.SaveChanges();
            return View(vm);
        }
    }
}
