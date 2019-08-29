using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using InvoiceModule.Models;
using InvoiceModule.Services.Services.Interfaces;

namespace InvoiceModule.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            try
            {
                var users = _userService.GetUsers();
                return View(users);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
