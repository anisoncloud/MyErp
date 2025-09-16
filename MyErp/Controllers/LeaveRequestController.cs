using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyErp.Data;
using MyErp.Models;
using MyErp.ViewModels;

namespace MyErp.Controllers
{
    public class LeaveRequestController : Controller
    {
        private readonly AppDbContex _context;
        private readonly SignInManager<Users> _signInManager;
        private readonly UserManager<Users> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public LeaveRequestController(SignInManager<Users> signInManager, UserManager<Users> userManager, RoleManager<IdentityRole> roleManager, AppDbContex context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }
        public IActionResult Index()
        {
            var leaveRequest = _context.LeaveRequests.Where(x => x.LeaveStauts == "Pending").ToList();
            return View(leaveRequest);
        }

        [HttpGet]
        public IActionResult Create()
        {           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveRequestViewModel vm)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("LogIn", "Accounts");
            }
            var leaveRequest = new LeaveRequest
            {
                EmpId = user.Id,
                StartDate = vm.StartDate,
                EndDate = vm.EndDate,
                Days = vm.Days,
                Comment = vm.Comment,
                LeaveType = vm.LeaveType,
                ManagerEmail = vm.ManagerEmail,
            };
            _context.LeaveRequests.Add(leaveRequest);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
