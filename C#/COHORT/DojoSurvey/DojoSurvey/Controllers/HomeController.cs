    using Microsoft.AspNetCore.Mvc;
    namespace DojoSurvey.Controllers     //be sure to use your own project's namespace!
    {
        public class HomeController : Controller   //remember inheritance??
        {
            //for each route this controller is to handle:
            [HttpGet]       //type of request
            [Route("")]     //associated route string (exclude the leading /)
            public ViewResult Index()
            {
                return View();
            }

            // [HttpGet("result")]
            // public ViewResult Result()
            // {
            //     return View("Result");
            // }

            [HttpPost]
            [Route ("result")]
            public IActionResult Method(string yourname, string location, string language, string comment)
            {
                ViewBag.name = yourname;
                ViewBag.loc = location;
                ViewBag.lang = language;
                ViewBag.com = comment;
                return View("Result");
            }

        }
    }