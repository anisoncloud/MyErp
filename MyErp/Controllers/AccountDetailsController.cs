using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyErp.Models;
using MyErp.ViewModels;

namespace MyErp.Controllers
{
    public class AccountDetailsController : Controller
    {
        private readonly UserManager<Users> _userManager;

        public AccountDetailsController(UserManager<Users> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Edit(string userId)
        {
            //var user = _userManager.Users.FirstOrDefault(u => u.Id == userId);
            var user = _userManager.Users
                .Include(u => u.UserDetails)
                .FirstOrDefault(u => u.Id == userId);
            var userDetails = new AccountDetailsViewModel
            {
                UserId = userId,
                FullName = user?.FullName,
                PhoneNumberOne = user?.UserDetails?.PhoneNumberOne,
                PhoneNumberTwo = user?.UserDetails?.PhoneNumberTwo,
                AddressOne = user?.UserDetails?.AddressOne,
                AddressTwo = user?.UserDetails?.AddressTwo
            };


            return View(userDetails);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(AccountDetailsViewModel model, string userId)
        {
            var user = _userManager.Users.FirstOrDefault(x=>x.Id == userId);
            if (user == null) 
            {
                return NotFound("User not available.");
            }

            if (ModelState.IsValid)
            {
                
            }
            return View();
        }

    }
}
