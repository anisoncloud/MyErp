using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyErp.Models;
using MyErp.ViewModels;

namespace MyErp.Controllers
{
    public class RoleController : Controller
    {
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(UserManager<Users> userManager, SignInManager<Users> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
            {
                ModelState.AddModelError("", "Role name cannot be empty.");
                return View();
            }
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                var role = new IdentityRole(roleName);
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Role already exists.");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AssignRole(string userId)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == userId);
            var roles = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);

            var listUserRoles = new List<SelectListItem>();
            foreach (var role in roles) {
                var hasRoles = userRoles.Any(ur=>ur.Contains(role.Name));
                listUserRoles.Add(new SelectListItem(role.Name, role.Id, hasRoles));
            };
            var theUser = new UserRoleViewModel()
            {
                UserName = user.UserName,
                UserId = userId,
                Roles = listUserRoles
            };

            return View(theUser);

        }

        //[HttpGet]
        //public async Task<IActionResult> AssignRole(string userId)
        //{
        //    var user = _userManager.Users.FirstOrDefault(u => u.Id == userId);
        //    var roles = _roleManager.Roles.ToList();
        //    var userRoles = await _userManager.GetRolesAsync(user);
        //    var viewModel = new UserRoleViewModel
        //    {
        //        UserId = userId,
        //        UserName = user?.UserName ?? "Unknown User",
        //        Roles = roles.Select(role => new RoleSelection
        //        {
        //            RoleName = role.Name,
        //            IsSelected = userRoles.Contains(role.Name)
        //        }).ToList()
        //    };
        //    return View(viewModel);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignRole(string userId, string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
            {
                ModelState.AddModelError("", "Role name cannot be empty.");
                return View();
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ModelState.AddModelError("", "User not found.");
                return View();
            }
            if (await _roleManager.RoleExistsAsync(roleName))
            {
                var result = await _userManager.AddToRoleAsync(user, roleName);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Role does not exist.");
            }
            return View();
        }
    }
}
