using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyErp.Data;
using MyErp.Models;

namespace MyErp.Controllers
{
    public class LeaveApprovalController : Controller
    {
        private readonly AppDbContex _context;
        private readonly SignInManager<Users> _signInManager;
        private readonly UserManager<Users> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public LeaveApprovalController(SignInManager<Users> signInManager, UserManager<Users> userManager, RoleManager<IdentityRole> roleManager, AppDbContex context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var leaveRequest = _context.LeaveRequests.Where(x => x.Stauts == "Pending" && x.ManagerEmail==user.Email).ToList();
            return View(leaveRequest);
        }
        public async Task<IActionResult> BulkAction(int[] selectedRequests, string actionType)
        {
            if(selectedRequests==null  || actionType.Length == 0)
            {
                TempData["Error"] = "No Data Selected";
                return RedirectToAction("Index");
            }
            var leaveRequests = _context.LeaveRequests
                .Where(lr => selectedRequests.Contains(lr.ID))
                .ToList();

            foreach (var leaveRequest in leaveRequests)
            {
                switch (actionType)
                {
                    case "Approve":
                        leaveRequest.Stauts = "Approved";
                        break;
                    case "Decline":
                        leaveRequest.Stauts = "Declined";
                        break;
                    case "Forward":
                        leaveRequest.Stauts = "Forwarded";
                        break;
                    default:
                        break;
                }
            }
            await _context.SaveChangesAsync();
            return View();
        }
    }
}
