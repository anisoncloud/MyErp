using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyErp.Data;
using MyErp.Models;

namespace MyErp.Controllers
{
    public class LeaveAllocationController : Controller
    {
        private readonly AppDbContex _context;
        private readonly SignInManager<Users> _signInManager;
        private readonly UserManager<Users> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public LeaveAllocationController(SignInManager<Users> signInManager, UserManager<Users> userManager, RoleManager<IdentityRole> roleManager, AppDbContex context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context; ;
        }

        public IActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public IActionResult Create(string id)
        {
            /*var user = _userManager.Users
                .Where(u => u.Id == id)
                .Include(u=>u.LeaveAllocation)
                .ToList();*/
            var user = _context.LeaveAllocations
                .Include(x=>x.Users)
                .SingleOrDefault(x=>x.EmpId==id);
            if (user == null)
            {
                return NotFound();
            }
            var leaveAllocation = new LeaveAllocation
            {
                Sick = user.Sick,
                Casual = user.Casual,
                Earned = user.Earned,
                Maternity = user.Maternity,
                Paternity = user.Paternity,
                Pilgrimage = user.Pilgrimage,
                Compensation = user.Compensation,

            };
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LeaveAllocation model, string id)
        {
            var user = _context.LeaveAllocations.SingleOrDefault(x => x.EmpId == id);
            if (user == null)
            {
                return NotFound();
            }
            user.Sick = model.Sick;
            user.Casual = model.Casual;
            user.Earned = model.Earned;
            user.Maternity = model.Maternity;
            user.Paternity = model.Paternity;
            user.Compensation = model.Compensation;
            _context.LeaveAllocations.Update(user);
            _context.SaveChanges();
            return View(user);
        }
    }
}
