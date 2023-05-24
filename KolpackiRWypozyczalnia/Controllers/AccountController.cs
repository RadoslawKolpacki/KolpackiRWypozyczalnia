using KolpackiRWypozyczalnia.Models;
using KolpackiRWypozyczalnia.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace KolpackiRWypozyczalnia.Controllers
   
{
    public class AccountController
    {

        UserManager<AppUser> UserManager { get; }

        SignInManager<AppUser> signInManager { get; }

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            UserManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                var newUser = new AppUser()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    UserName = user.Username,
                    Password = user.Password
                };

                var result = await UserManager.CreateAsync(newUser, newUser.Password);

                ViewBag.result = result.Errors.ToList();
            }
            return View();
        }

        private IActionResult View()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult Register()
        {
            
        }

        public async Task<IActionResult> Login(LoginViewModel login)
    }
}
