using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoginRegNew.Models;

namespace LoginRegNew.Controllers
{
    public class HomeController : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("Register")]
    public IActionResult Register(User NewUser)
    {
        // To get the submitted User from the submission, 
        // we would just need to grab "NewUser" from the modelData object
        User submittedUser = NewUser;
        if(ModelState.IsValid)
        {
            return View("Success");
        }
        return View("Index");
    }
    [HttpPost("Login")]
    public IActionResult Login(LoginUser NewLoginUser)
    {
        // To get the submitted User from the submission, 
        // we would just need to grab "NewUser" from the modelData object
        LoginUser submittedLoginUser = NewLoginUser;
        if(ModelState.IsValid)
        {
            return View("Success");
        }
        return View("Index");
    }

    [HttpGet("Success")]
    public string Success()
    {
        return "You have successfully submitted!";
    }
}
}
