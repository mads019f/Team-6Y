using Matematik5_0.Models;
using Matematik5_0.Models.WebModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Matematik5_0.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Service _service;

        public HomeController ( ILogger<HomeController> logger, Service service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ActionResult> Index ( )
        {
            ViewBag.ExcerciseCategory = await _service.GetExcerciseCategoriesAsync();
            
            return View();
        }

        public IActionResult Privacy ( )
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error ( )
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult RedirectToExcersiceCategories()
        {
            return RedirectToAction("Index", "ExcerciseCategories"); 
        }


    }
}
