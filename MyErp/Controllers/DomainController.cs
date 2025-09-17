using Microsoft.AspNetCore.Mvc;
using MyErp.Data;

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
            return View();
        }

        [HttpGet] 
        public IActionResult Create()
        {
            var crmCompanies = _context.CrmCompanies.ToList();
            return View();
        }
    }
}
