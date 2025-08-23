using Microsoft.AspNetCore.Mvc;
using MyErp.Data;
using MyErp.Models;

namespace MyErp.Controllers
{
    public class CrmCompanyController : Controller
    {
        private readonly AppDbContex _dbContext;

        public CrmCompanyController(AppDbContex dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var companies = _dbContext.CrmCompanies.ToList();

            return View(companies);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CrmCompany model)
        {
            if (ModelState.IsValid) 
            {
                _dbContext.CrmCompanies.Add(model);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
