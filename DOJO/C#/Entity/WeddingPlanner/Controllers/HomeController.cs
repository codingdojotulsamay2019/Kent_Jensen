using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        public MyContext dbContext;

        public HomeController(MyContext context)
        {
            dbContext=context;
        }

        //ROOT ROUTE - Register form
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost("")]
        public IActionResult Register(User user)
        {
            // Check initial ModelState
            if(ModelState.IsValid)
            {
                // If a User exists with provided email
                if(dbContext.Users.Any(u => u.Email == user.Email))
                {
                    // Manually add a ModelState error to the Email field, with provided
                    // error message
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("Index");
                }
                else
                {
                    // Initializing a PasswordHasher object, providing our User class as its
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    user.Password = Hasher.HashPassword(user, user.Password);
                    dbContext.Add(user);
                    dbContext.SaveChanges();

                    //save a copy of info into session.
                    HttpContext.Session.SetString("UserName", user.Email);
                    HttpContext.Session.SetInt32("UserId", user.UserId);
                    return RedirectToAction("Dashboard");
                }
            }
            else
            {
                ModelState.AddModelError("Email", "Invalid Email/Password!");
                return View("Index");
            }
        }

        //Get Login page
        [HttpGet("login")]
        public IActionResult LoginLoad()
        {
            return View("Index");
        }



        //Handle POST data from Login page form
        [HttpPost("login")]
        public IActionResult Login(LoginUser submittedUser)
        {
            if(ModelState.IsValid)
            {
                // gets UserName value from session, stores as UserEmail
                var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == submittedUser.LoginEmail);
                //create an instance of LoginUser to contain info. 
            
                //if User in db is null... reject login.
                if(userInDb == null)
                {
                    //Add an error to the ModelState and return to View.
                    ModelState.AddModelError("Email", "Invalid Email/Password - 1");
                    return View("Index");
                }
                
                    //intializes hasher object
                    var hasher = new PasswordHasher<LoginUser>();
                    //verify provided password against hash stored in db
                    var result = hasher.VerifyHashedPassword(submittedUser, userInDb.Password, submittedUser.LoginPassword);
                    // 0 == failure.
                    if(result == 0)
                    {
                        //failure
                        ModelState.AddModelError("Email", "Invalid Email/Password");
                        return View("Index");
                    }
                    else
                    {
                        HttpContext.Session.SetString("UserName", userInDb.Email);
                        HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                        return RedirectToAction("Dashboard");
                    }
                }
                return View("Index");
        }


        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }


        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            ViewBag.UserId = UserId;
            if(UserId == null)
            {
                return View("Index");
            }
            else
            {
                List<Event> allEvents = dbContext.Events
                .Include(a => a.allUsersAttending)
                .ToList();
                return View(allEvents);
            }
        }

        [HttpGet("newEvent")]
        public IActionResult newEvent()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            ViewBag.UserId = UserId;
            if(UserId == null)
            {
                return View("Index");
            }
            else
            {
                return View("newEvent");
            }

        }
        [HttpPost("newEvent")]
        public IActionResult createEvent(Event Event)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            ViewBag.UserId = UserId;
            if(UserId == null)
            {
                return View("Index");
            }
            else
            {
                if(ModelState.IsValid)
                {
                    int? OwnerId = HttpContext.Session.GetInt32("UserId");
                    dbContext.Add(Event);
                    dbContext.SaveChanges();
                    return RedirectToAction("showEvent", new { EventId = Event.EventId});
                }
                else
                {
                    return View("newEvent");
                }
            }
        }

        [HttpGet("showEvent/{EventId}")]
        public IActionResult showEvent(int EventId)
        {
            var EventInDb = dbContext.Events
            .Include(u => u.allUsersAttending)
            .ThenInclude(e => e.User)
            .FirstOrDefault(u => u.EventId == EventId);
            return View(EventInDb);
        }

        [HttpGet("RSVP/{EventId}")]
        public IActionResult RSVP(int EventId)
        {
            //instantiates user
            User thisUser = dbContext.Users.
            FirstOrDefault(u => u.UserId == HttpContext.Session
            .GetInt32("UserId"));

            Event thisEvent = dbContext.Events
            .Include(a => a.allUsersAttending)
            .ThenInclude(b => b.User)
            .FirstOrDefault(u => u.EventId == EventId);

            Attending thisGuest = dbContext.Attendings.Where(a => a.EventId == EventId && a.UserId == thisUser.UserId)
            .FirstOrDefault();
            if(thisGuest != null)
            {
                thisEvent.allUsersAttending.Remove(thisGuest);
            }
            else
            {
                Attending NewGuest = new Attending 
                {
                    UserId = thisUser.UserId,
                    EventId = thisEvent.EventId,
                };
                thisEvent.allUsersAttending.Add(NewGuest);
            }
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("delete/{deleteId}")]
        public IActionResult Delete(int deleteId)
        {
            Event deleteEvent = dbContext.Events
            .FirstOrDefault(a => a.EventId == deleteId);
            dbContext.Events.Remove(deleteEvent);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
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