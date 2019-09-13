using Microsoft.AspNetCore.Mvc;
namespace HelloASP 
{
    public class HomeController : Controller
    {
        //Requests
        //localhost:5000/
        [Route("")]
        [HttpGet] //GET request handling

        //response will be a method, or action.
        public ViewResult Index()
        {
            return View();
        }
        
        //Requests
        //localhost:5000/projects
        //this below line does the same as the above route, just in one line rather than 2. 
        [HttpGet("projects")]
        public ViewResult Projects()
        {
            return View();
        }
        // localhost:5000/contact
        [HttpGet("contact")]
        public ViewResult Contact()
        {
            return View();
        }
    }

}