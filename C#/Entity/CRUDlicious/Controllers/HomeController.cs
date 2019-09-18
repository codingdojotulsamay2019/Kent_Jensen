using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Crudlicious.Models;
using Microsoft.EntityFrameworkCore;

namespace Crudlicious.Controllers
{
    public class HomeController : Controller
    {
        public MyContext dbContext;

        //here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            dbContext=context;
        }

        //ROOT ROUTE populates with list of dishes from DB
        [HttpGet("")]
        public IActionResult Index()
        {
            // list of dishes
            List<Dish> AllDishes = dbContext.Dishes
                .OrderByDescending(u => u.CreatedAt)
                .ToList();
            return View(AllDishes);
        }

        // **not needed**
        // public IActionResult Recent()
        // {
        //     // Get the 5 most recently added Dishes
        //     List<Dish> MostRecent = dbContext.Dishes
        //         .OrderByDescending(u => u.CreatedAt)
        //         .Take(5)
        //         .ToList();
        //     return View("Index", MostRecent);
        // }

        //SHOW view
        [HttpGet("{ID}")]
        public IActionResult GetOneDish(int ID)
        {
            Dish oneDish = dbContext.Dishes.FirstOrDefault(Dish => Dish.ID == ID);
            // Other code
            return View("Show", oneDish);
        }


        //return form to submit new dish
        [HttpGet("new")]
        public IActionResult Form()
        {
            return View();
        }


        //post form to db
        [HttpPost("new")]
        public IActionResult NewDish(Dish oneDish)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(oneDish);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Form", oneDish);
            };
        }


        //Grabs data to display on EditForm.cshtml
        [HttpGet("edit/{tempid}")]
        public IActionResult Edit(int tempid)
        {
            Dish oneDish = dbContext.Dishes.SingleOrDefault(Dish => Dish.ID == tempid);
            return View("EditForm", oneDish);
        }


        //POST request from EditForm w/ Dish object.
        [HttpPost("edit/{tempid}")]
        public IActionResult Edit(Dish oneDish, int tempid)
        {
            if(ModelState.IsValid)
            {
                Dish dish = dbContext.Dishes.SingleOrDefault(a => a.ID == tempid);
                dish.Name = oneDish.Name;
                dish.Chef = oneDish.Chef;
                dish.Description = oneDish.Description;
                dish.Tastiness = oneDish.Tastiness;
                dish.Calories = oneDish.Calories;
                dish.UpdatedAt = oneDish.UpdatedAt;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("EditForm", oneDish);
            };
        }


        [HttpGet("delete/{tempid}")]
        public IActionResult Delete(int tempid)
        {
            Dish thisdish = dbContext.Dishes.SingleOrDefault(a => a.ID == tempid);
            dbContext.Dishes.Remove(thisdish);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
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
