using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MVC.Models;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {
            ViewData["Title"] = "ورود";
            return View();
        }
        public IActionResult Forget()
        {
            ViewData["Title"] = "فراموشی رمز عبور";
            return View();
        }
        public IActionResult Register()
        {
            ViewData["Title"] = "ثبت نام";
            return View();
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
