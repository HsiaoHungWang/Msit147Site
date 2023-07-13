using Microsoft.AspNetCore.Mvc;

namespace Msit147Site.Controllers
{
    public class ApiController : Controller
    {
        public IActionResult Index()
        {
            // return Content("Hello World!!");
            // return Content("<h2>Hello World!!</h2>","text/html");
            //return Content("<h2>Ajax 您好!!</h2>", "text/html", System.Text.Encoding.UTF8);

            return Content("Hello World!!", "application/msword");          
                
        }
    }
}
