using MyErp.Models;
using MyErp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyErp.Data;

namespace MyErp.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContex _context;
        private readonly SignInManager<Users> _signInManager;
        private readonly UserManager<Users> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(SignInManager<Users> signInManager, UserManager<Users> userManager, RoleManager<IdentityRole> roleManager, AppDbContex context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }
       

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.Users.ToListAsync();
                return View(user);
        }

        public IActionResult Login()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    // Logic to redirect to a secure area
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return RedirectToAction("LogIn", "Account");
                }
                // Logic to authenticate user
                // If successful, redirect to a secure area
                
            }
            return View(model);
        }
        public IActionResult Register()
        {
            var vm = new RegisterViewModel
            {
                Departments = _context.Departments
                .Select(x => new SelectListItem
                {
                    Value = x.ID.ToString(),
                    Text = x.Name
                }).ToList(),
                Companies = _context.Companies
                .Select(y => new SelectListItem
                {
                    Value = y.ID.ToString(),
                    Text = y.Name
                }).ToList()

            };
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model) {
            //if (ModelState.IsValid)
            //{
                var user = new Users { 
                    UserName = model.Email, 
                    Email = model.Email, 
                    FullName = model.FullName,
                    NormalizedUserName = model.Email.ToUpper(),
                    NormalizedEmail = model.Email.ToUpper(),
                    DepartmentId = model.DepartmentId,
                    CompanyId = model.CompanyId,
                    
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var roleExists = await _roleManager.RoleExistsAsync("User");
                    if (!roleExists)
                    {
                        await _roleManager.CreateAsync(new IdentityRole("User"));
                    }
                    await _userManager.AddToRoleAsync(user, "User");
                    //After register sign in to a this user
                    //await _signInManager.SignInAsync(user, isPersistent: true);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                // Logic to register user
                // If successful, redirect to a secure area or login page
                //return RedirectToAction("Index", "Home");
            //}
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult VerifyEmail()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VerifyEmail(VerifyEmailViewModel model)
        {
            if (!ModelState.IsValid) 
            {
                return View(model);
            }

                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user==null)
                {
                    ModelState.AddModelError("", "User not Found");
                    return View(model);
                }
                else
                {
                    return RedirectToAction("ChangePassword", "Account", new { username = user.UserName });
                }
           
        }

        [HttpGet]
        public IActionResult ChangePassword(string username) 
        {
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("VerifyEmail", "Account");
            }
            return View(new ChangePasswordViewModel { Email = username });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something Went Wrong");
                return View(model);
            }
            else
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    ModelState.AddModelError("", "User not found");
                    return View(model);
                }
                var result = await _userManager.RemovePasswordAsync(user);
                if (result.Succeeded)
                {
                    result = await _userManager.AddPasswordAsync(user, model.NewPassword);
                    return RedirectToAction("Login", "Account");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View(model);
                }                
            }
            return View(model);
        }
    }
}
