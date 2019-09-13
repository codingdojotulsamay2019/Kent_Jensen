using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FormSubmission.Models;

namespace FormSubmission.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("form")]
        public IActionResult Submission(User newUser)
        {
            Console.WriteLine(newUser);
            if(ModelState.IsValid)
            {
                return RedirectToAction("Success", newUser);
            }
            else
            {
                return View("Index", newUser);
            };
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


        [HttpGet("Success")]
        public IActionResult Success()
        {
            Console.WriteLine("In success");
            return View();
        }
    }
}