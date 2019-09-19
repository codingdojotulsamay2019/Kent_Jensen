using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;

namespace ChefsNDishes.Controllers
{
    public class HomeController : Controller
    {
        public MyContext dbContext;

        //here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            dbContext=context;
        }
        public IActionResult Index()
        {
            List<Dish> CreatedDishes = dbContext.CreatedDishes
            // populates each Message with its related User object (Creator)
            .Include(message => message.Creator)
            .ToList();
    
            return View(CreatedDishes);
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
