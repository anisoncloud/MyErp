using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyErp.Data;
using MyErp.Models;
using System.Threading.Tasks;

namespace MyErp.Controllers
{
    public class EmployeeAttendanceController : Controller
    {
        private readonly AppDbContex _context;
        private readonly SignInManager<Users> _signInManager;
        private readonly UserManager<Users> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public EmployeeAttendanceController(SignInManager<Users> signInManager, UserManager<Users> userManager, RoleManager<IdentityRole> roleManager, AppDbContex context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            var user = await _userManager.Users
                .Include(x => x.Company)
                .Include(y => y.Department)
                .Include(z => z.Designation)
                .Include(c=>c.EmployeeAttendances)
                .ToListAsync();
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost(EmployeeAttendance ea)
        {
            var user = await _userManager.Users.FirstAsync(x => x.CustomEmployeeId == ea.CustomEmployeeId);
            if (user == null)
            {
                return NotFound();
            }
            var attendanceExists = _context.EmployeeAttendances.FirstOrDefault(x=>x.EmployeeId == user.Id);
            if (attendanceExists == null)
            {
                var employeeAttendance = new EmployeeAttendance
                {
                    EmployeeId = user.Id,
                    CustomEmployeeId = ea.CustomEmployeeId,
                    InTime = DateTime.Now,
                };
                _context.EmployeeAttendances.Add(employeeAttendance);
                _context.SaveChanges();
            }
            else
            {
                attendanceExists.OutTime = DateTime.Now;                
                _context.Update(attendanceExists);
                _context.SaveChanges();
            }
                return RedirectToAction("Create");
        }
    }
}
