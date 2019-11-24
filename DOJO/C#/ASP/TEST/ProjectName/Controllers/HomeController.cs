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
        public string Index()
        {
            return "Hello From Controller!";
        }
        

        //Requests
        //localhost:5000/hello
        //this below line does the same as the above route, just in one line rather than 2. 
        [HttpGet("hello")]
        public string Hello()
        {
            return "Hi Again!";
        }
        // localhost:5000/users/???
        [HttpGet("users/{username}/{location}")]
        public string HelloUser(string username, string location)
        {
            if(location =="Chicago") //allows you to provide custom responses based on inputs given through url.
                return $"Hello {username} from {location}. Go Bears!";
            return $"Hello {username} from {location}!";

        }
    }

}