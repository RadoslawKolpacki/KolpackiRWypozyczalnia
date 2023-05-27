using KolpackiRWypozyczalnia.Models;
using KolpackiRWypozyczalnia.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace KolpackiRWypozyczalnia.Controllers
{
    public class AccountController : Controller
    {
        UserManager<AppUser> userManager { get; }

        SignInManager<AppUser> signInManager { get; }

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
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
                    UserName = user.UserName,
                    Password = user.Password,
                    Email = user.Email
                };

                var result = await userManager.CreateAsync(newUser, newUser.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(newUser, false);

                    return RedirectToAction("Index", "Home");
                }
                else
                {

                    var errorList = result.Errors.ToList();
                    ViewBag.result = string.Join("\n", errorList.Select(e => e.Description));
                }
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var result = await signInManager.PasswordSignInAsync(user.Login, user.Password, false, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Nieudana próba logowania");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}
