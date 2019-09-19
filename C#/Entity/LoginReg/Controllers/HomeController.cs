using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoginReg.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;


namespace LoginReg.Controllers
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
                    return RedirectToAction("success");
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
            return View("Login");
        }



        //Handle POST data from Login page form
        [HttpPost("login")]
        public IActionResult Login(LoginUser submittedUser)
        {
            if(ModelState.IsValid)
            {
                // gets UserName value from session, stores as UserEmail
                string UserEmail = HttpContext.Session.GetString("UserName");
                var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == submittedUser.Email);

                //create an instance of LoginUser to contain info. 
                LoginUser thisUser = new LoginUser();
                thisUser.Email = submittedUser.Email;
                thisUser.Password = submittedUser.Password;
            
                //if User in db is null... reject login.
                if(userInDb == null)
                {
                    //Add an error to the ModelState and return to View.
                    ModelState.AddModelError("Email", "Invalid Email/Password - 1");
                    return View("Login");
                }
                //if UserEmail in session is null and the submitted user is null... reject. 
                if(thisUser.Email == null)
                {
                    ModelState.AddModelError("Email", "Invalid Email/Password - 2");
                    return View("Login");
                }
                //if thisUSer.Email doesn't match db result
                if(thisUser.Email != userInDb.Email)
                {
                    ModelState.AddModelError("Email", "Invalid Email/Password - 3");
                    return View("Login");
                }
                else
                {
                    //intializes hasher object
                    var hasher = new PasswordHasher<LoginUser>();
                    //verify provided password against hash stored in db
                    var result = hasher.VerifyHashedPassword(thisUser, userInDb.Password, thisUser.Password);
                    // 0 == failure.
                    if(result == 0)
                    {
                        //failure
                        ModelState.AddModelError("Email", "Invalid Email/Password");
                        return View("Login");
                    }
                    else
                    {
                        if (userInDb.Email != thisUser.Email)
                        {
                            return View("Login");
                        }
                        else
                        {
                            return View("Success", thisUser);
                        }
                    }
                }
            }
            return View("Login");
        }


        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }


        [HttpGet("Success")]
        public IActionResult Success()
        {
            string UserEmail = HttpContext.Session.GetString("UserName");
            if(UserEmail == null)
            {
                return View("Login");
            }
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