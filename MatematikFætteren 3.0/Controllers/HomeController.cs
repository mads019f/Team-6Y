using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MatematikFætteren_3._0.Models;
using MatematikFætteren_3._0.Data;
using MatematikFætteren_3._0.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace MatematikFætteren_3._0.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IdentityContext _identityContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, RoleManager<IdentityRole> roleManager, IdentityContext identityContext)
        {
            _logger = logger;
            _context = context;
            _roleManager = roleManager;
            _identityContext = identityContext;
        }

        public IActionResult Index()
        {
            IdentityRole identityRole = new IdentityRole("user");
            _roleManager.CreateAsync(identityRole);
            return View();
        }

        [Authorize(Roles = "user")]
        public IActionResult Users()
        {
            UserViewModel userViewModel = new UserViewModel
            {
                Users = _identityContext.Users.ToList(),
                UserRoles = _identityContext.UserRoles.ToList(),
                Roles = _identityContext.Roles.ToList()
            };

            return View(userViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
