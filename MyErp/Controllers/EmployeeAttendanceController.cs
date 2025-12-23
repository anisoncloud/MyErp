using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyErp.Data;
using MyErp.Models;
using MyErp.ViewModels;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            /*var user = await _userManager.Users
                .Include(x => x.Company)
                .Include(y => y.Department)
                .Include(z => z.Designation)
                .Include(c=>c.EmployeeAttendances)
                .ToListAsync();
            return View(user);*/

            var today = DateTime.Today.Month;
            var todaysEmployees = _context.EmployeeAttendances
                .Where(x => x.InTime.Value.Date.Month == today)
                .Include(x => x.Users)
                .ThenInclude(x=>x.Company)
                .Include(x=>x.Users)
                .ThenInclude(x => x.Department)

                .ToList();
            return View(todaysEmployees);
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
            //var attendanceExists = _context.EmployeeAttendances.FirstOrDefault(x=>x.EmployeeId == user.Id);
            var attendanceExists = _context.EmployeeAttendances
                .FirstOrDefault(x=>x.InTime.Value.Date==DateTime.Today && x.EmployeeId == user.Id);
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
        [HttpGet]
        public IActionResult Details(string id)
        {
            var selectedMonth = DateTime.Now.Month;
            var selectedMontAttendance = _context.EmployeeAttendances
                .Where(x => x.InTime.Value.Month == selectedMonth && x.EmployeeId==id)
                .Include(x => x.Users)
                .ToList();
            return View(selectedMontAttendance);
        }
        [HttpGet]
        public IActionResult MonthlyAttendance(int year, int month)
        {
            int WorkingDaysInAMonth;
            if (year==0 && month==0)
            {                
                year = DateTime.Today.Year;
                month = DateTime.Today.Month;
            }            
                WorkingDaysInAMonth = GetWorkingDays(year, month);
            
            var data = _context.EmployeeAttendances
                .Where(
                a => a.InTime.Value.Year == year
                && a.InTime.Value.Month == month)
                .Select(a => new
                {
                    a.EmployeeId,
                    Day = a.InTime.Value.Date,
                    a.CustomEmployeeId
                })
                .Distinct()
                .ToList();
            var result = data
                .GroupBy(x => x.EmployeeId)
                .Select(g => new MonthlyAttendanceViewModel
                {
                    EmployeeId = g.Key,
                    CustomEmployeeId = _context.EmployeeAttendances.Where(e=>e.EmployeeId==g.Key).Select(a=>a.CustomEmployeeId).FirstOrDefault(),
                    EmployeeName = _userManager.Users
                    .Where(e => e.Id == g.Key)
                    .Select(e => e.FullName)
                    .FirstOrDefault(),
                    PresentDays = g.Count(),
                    WorkingDaysInAMonth = WorkingDaysInAMonth
                }).ToList();
            return View(result);
        }

        // Get Working days in a Month
        public int GetWorkingDays(int year, int month)
        {
            
            int TotalDaysInAMonth = DateTime.DaysInMonth(year, month);
            // Year and Month Current then show only the current month
            if (year == DateTime.Today.Year && month == DateTime.Today.Month)
            {
                TotalDaysInAMonth = DateTime.Today.Day;
            }
            int WorkingDaysInAMonth = 0;
            for (int day = 1; day < TotalDaysInAMonth; day++)
            {
                var Date = new DateTime(year, month, day);
                if (Date.DayOfWeek != DayOfWeek.Friday && Date.DayOfWeek != DayOfWeek.Saturday)
                {
                    WorkingDaysInAMonth++;
                }
            }
            return WorkingDaysInAMonth;
        }

        public IActionResult EmployeeMonthlyDetails(string employeeId, int year, int month)
        {
            if (year == 0 && month == 0)
            {
                year = DateTime.Today.Year;
                month = DateTime.Today.Month;
            }
            var startDate = new DateTime(year, month, 1);
            var endDate = startDate.AddMonths(1);
            var holiDaysInAMonth = _context.PublicHolidays
                .Where(h => h.HolidayDate >= startDate && h.HolidayDate < endDate)
                .Select(h => h.HolidayDate.Date)
                .ToHashSet();
            var employeeAttendace = _context.EmployeeAttendances
                .Where(e=>e.EmployeeId == employeeId && e.InTime>=startDate && e.InTime<endDate)
                .ToList();

            var result = new List<DailyAttendanceViewModel>();
            for (var date = startDate; date < endDate; date = date.AddDays(1))
            {
                var dayAttendance = employeeAttendace
                    .Where(a=>a.InTime.Value.Date  ==  date.Date)
                    .OrderBy(a=>a.InTime)
                    .FirstOrDefault();

                string status;

                if (date.DayOfWeek == DayOfWeek.Friday)
                    status = "Friday";
                else if (date.DayOfWeek == DayOfWeek.Saturday)
                    status = "Saturday";
                else if (holiDaysInAMonth.Contains(date.Date))
                    status = "Holiday";
                else if (dayAttendance != null)
                    status = "Present";
                else
                    status = "Absent";

                result.Add(new DailyAttendanceViewModel
                {
                    Date = date,
                    InTime = dayAttendance?.InTime?.TimeOfDay,
                    OutTime = dayAttendance?.OutTime?.TimeOfDay,
                    Status = status
                });
            }

            return View(result);
        }
    }
}
