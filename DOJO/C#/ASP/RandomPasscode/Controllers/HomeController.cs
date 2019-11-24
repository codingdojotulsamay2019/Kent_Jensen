using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RandomPasscode.Models;
using Microsoft.AspNetCore.Http;

namespace RandomPasscode.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            int? IntVariable = HttpContext.Session.GetInt32("count");
                if(IntVariable==null)
                {
                    HttpContext.Session.SetInt32("count", 1);

                }
                else
                    HttpContext.Session.SetInt32("count", +1);
            ViewBag.Count = HttpContext.Session.GetInt32("count");
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
        public IActionResult Generate()
        {
            //Need to generate passcode here and store it in TempData.


            return View("Index");
        }
    }
}
