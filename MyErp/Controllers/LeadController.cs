using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyErp.Data;
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
            return View();
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
    }
}
