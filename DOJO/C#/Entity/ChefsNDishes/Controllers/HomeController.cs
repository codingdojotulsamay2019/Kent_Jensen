using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet("")]
        public IActionResult Index()
        {
            List<Chef> AllChefs = dbContext.Chefs
            .Include(chef => chef.CreatedDishes)
            .ToList();
            return View(AllChefs);
        }

        [HttpGet("dishes")]
        public IActionResult allDishes()
        {
            List<Dish> CreatedDishes = dbContext.CreatedDishes
            // populates each Dish with its related Chef object (Creator)
            .Include(dish => dish.Creator)
            .ToList();
            return View("dishes",CreatedDishes);
        }
        //route to form to add new chef
        [HttpGet("new")]
        public IActionResult newChef()
        {
            return View();
        }
        //route for post data of chef
        [HttpPost("new")]
        public IActionResult addNewChef(Chef newChef)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(newChef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("newChef");
            }
        }

        //route to form to add new dish
        [HttpGet("dishes/new")]
        public IActionResult newDish()
        {
            List<Chef> AllTheChefs = dbContext.Chefs.ToList();
            ViewBag.ChefList = AllTheChefs;
            return View();
        }

        //route for post data of dish
        [HttpPost("dishes/new")]
        public IActionResult addNewDish(Dish newDish)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("allDishes");
            }
            else
            {
                List<Chef> AllTheChefs = dbContext.Chefs.ToList();
                ViewBag.ChefList = AllTheChefs;
                return View("newDish");
            }
        }

        [HttpGet("chefs/{chefId}")]
        public IActionResult ChefDetails(int chefId)
        {
            // Number of dishes created by this Chef
            int numDishes = dbContext.Chefs
                // Including Dishes, so that we may query on this field
                .Include(chef => chef.CreatedDishes)
                // Get a Chef with chefId
                .FirstOrDefault(chef => chef.ChefId == chefId)
                // Now, with a reference to a Chef object, and access to a Chefs Dishes
                // We can get the .Count property of the Dishes List
                .CreatedDishes.Count;
            
            // Chef with the longest Dish, we can do this in two stages
            // First, find the Length of the longest Dish
            int longestDishLength = dbContext.Dishes.Max(dish => dish.Description.Length);
            
            // Second, select one Chef who's CreatedDishes has Any that matches this character count
            // Note here that CreatedDishes is a List, and thus can take a LINQ expression: such as .Any()
            Chef chefWithLongest = dbContext.Chefs
                .Include(chef => chef.CreatedDishes)
                .FirstOrDefault(chef => chef.CreatedDishes
                    .Any(dish => dish.Description.Length == longestDishLength));
            
            // Dishes NOT related to this Chef:
            // Since this query only requires checking a Dish's ChefId
            // and doesn't require us to check data contained in a Dish's Creator
            // We can do this without a .Include()
            List<Dish> unrelatedDishes = dbContext.Dishes
                .Where(dish => dish.ChefId != chefId)
                .ToList();
            
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
