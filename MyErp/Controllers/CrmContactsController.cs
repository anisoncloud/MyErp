using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyErp.Data;
using MyErp.Models;
using MyErp.ViewModels;

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
            var contacts = _context.CrmContacts
                .Include(x=>x.CrmCompany)
                .ToList();
            return View(contacts);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var vm = new CrmContactViewModel
            {
                CrmCompany = _context.CrmCompanies
                .Select(x => new SelectListItem
                {
                    Value = x.ID.ToString(),
                    Text = x.Name
                }).ToList()
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CrmContactViewModel vm)
        {
            var contact = new CrmContact
            {
                Name = vm.Name,
                Email = vm.Email,
                Phone = vm.Phone,
                Photo = vm.Photo,
                CrmCompanyId = vm.CrmCompanyId
            };
            _context.CrmContacts.Add(contact);
            _context.SaveChanges();
            TempData["Success"] = "Contact Added Successfully";
            return RedirectToAction("Index");
        }
    }
}
