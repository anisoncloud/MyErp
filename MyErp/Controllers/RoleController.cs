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
        //Original Get
        [HttpGet]
        public async Task<IActionResult> AssignRole(string id)
        {
            //var user = _userManager.Users.FirstOrDefault(u => u.Id == userId);
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var allRoles = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);

            var model = new UserRoleViewModel
            {
                UserId = user.Id,
                Roles = allRoles.Select(role => new RoleSelection
                {
                    RoleName = role.Name,
                    IsSelected = userRoles.Contains(role.Name)
                }).ToList()
            };

            return View(model);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignRole(UserRoleViewModel vm)
        {
            
            var user = await _userManager.FindByIdAsync(vm.UserId);
            if (user == null)
            {
                ModelState.AddModelError("", "User not found.");
                return View();
            }
            var existingRoles = await _userManager.GetRolesAsync(user);
            var selectedRoles = vm.Roles.Where(r=>r.IsSelected)
                .Select(r=>r.RoleName).ToList();
            
            //remove unselected roles
            var rolesToRemove = existingRoles.Except(selectedRoles);
            await _userManager.RemoveFromRolesAsync(user, rolesToRemove);

            //Add newly selected roles
            var rolesToAdd = selectedRoles.Except(existingRoles);
            await _userManager.AddToRolesAsync(user, rolesToAdd);
            return RedirectToAction("Index", "Account");
        }
    }
}
