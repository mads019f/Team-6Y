using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matematik.Models.Forum.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Matematik.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;


        //Dependency Injection
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //Register
        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult Register()
        {

            return View(new RegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }

            var newUser = new IdentityUser
            {
                Email = registerViewModel.Email,
                UserName = registerViewModel.Username,

            };

            var result = await _userManager.CreateAsync(newUser, registerViewModel.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors.Select(x => x.Description))
                {
                    ModelState.AddModelError("", error);
                }
                return View();
            }
           
            return RedirectToAction("Login");
        }

        //Login
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }
        
        
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(
                login.Username, login.Password,
                login.RememberMe, false
            );

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Login error!");
                return View();
            }

            if (string.IsNullOrWhiteSpace(returnUrl))
                return RedirectToAction("Index", "Home");

            return Redirect(returnUrl);
        }

        [HttpPost]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();

            if (string.IsNullOrWhiteSpace(returnUrl))
                return RedirectToAction("Index", "Home");

            return Redirect(returnUrl);
        }
    }
}