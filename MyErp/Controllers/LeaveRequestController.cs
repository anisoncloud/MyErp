using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyErp.Data;
using MyErp.Models;

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
            return View();
        }

        public IActionResult Create()
        {
            string userId = _userManager.GetUserId(User);
            var user = _userManager.GetUserAsync(User);
            var leaveRequest = new LeaveRequest
            {
                EmpId = userId,
            };
            return View(user);
        }
    }
}
