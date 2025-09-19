using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyErp.Data;
using MyErp.Models;
using MyErp.ViewModels;

namespace MyErp.Controllers
{
    public class LeaveReportController : Controller
    {
        private readonly AppDbContex _context;
        private readonly SignInManager<Users> _signInManager;
        private readonly UserManager<Users> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public LeaveReportController(SignInManager<Users> signInManager, UserManager<Users> userManager, RoleManager<IdentityRole> roleManager, AppDbContex context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var leaveAllocation = _context.LeaveAllocations.FirstOrDefault(x => x.EmpId == user.Id);
            var enjoyedLeave = _context.LeaveRequests.Where(x => x.EmpId == user.Id && x.LeaveStauts == "Approved" && x.RequestDate.Year==DateTime.Now.Year).ToList();
            var vm = new LeaveReportViewModel
            {
                Users = user,
                LeaveAllocation = leaveAllocation,
                LeaveRequest = enjoyedLeave
            };
            return View(vm);
        }
    }
}
