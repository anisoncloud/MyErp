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
            if (user == null)
            {
                return RedirectToAction("login", "Account");
            }
            var leaveRequest = await _context.LeaveRequests
                .Where(x => x.LeaveStauts == "Pending" && x.ManagerEmail==user.Email).ToListAsync();
            return View(leaveRequest);
        }
        public async Task<IActionResult> BulkAction(int[] selectedRequests, string actionType)
        {
            if(selectedRequests==null  || actionType.Length == 0)
            {
                TempData["Error"] = "No Data Selected";
                return RedirectToAction("Index");
            }
            // The following code works in SQL Server version >=16    
            /*var leaveRequests = await _context.LeaveRequests
                .Where(lr => selectedRequests.Contains(lr.ID))
                .ToListAsync();*/

            var leaveRequests = new List<LeaveRequest>();
            foreach (var id in selectedRequests)
            {
                var req = await _context.LeaveRequests.FindAsync(id);
                if (req != null) leaveRequests.Add(req);
            }

            foreach (var leaveRequest in leaveRequests)
            {
                switch (actionType)
                {
                    case "Approve":
                        leaveRequest.LeaveStauts = "Approved";
                        break;
                    case "Decline":
                        leaveRequest.LeaveStauts = "Declined";
                        break;
                    case "Forward":
                        leaveRequest.LeaveStauts = "Forwarded";
                        break;
                    default:
                        break;
                }
            }
            await _context.SaveChangesAsync();
            TempData["Success"] = "Updated Accordingly";
            return RedirectToAction("Index");
        }
    }
}
