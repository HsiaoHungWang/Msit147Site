using Microsoft.AspNetCore.Mvc;
using Msit147Site.Models;

namespace Msit147Site.Controllers
{
    public class ApiController : Controller
    {
        private readonly DemoContext _context;

        public ApiController(DemoContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
             return Content("Hello Ajax!!");
            // return Content("<h2>Hello World!!</h2>","text/html");
            //return Content("<h2>Ajax 您好!!</h2>", "text/html", System.Text.Encoding.UTF8);

           // return Content("Hello World!!", "application/msword");          
                
        }

        public IActionResult AjaxEvent(string userName)
        {
            if(string.IsNullOrEmpty(userName))
            {
                userName = "Guest";
            }
            return Content("Hello " + userName);
        }

        public IActionResult Cities() {
            var cities = _context.Address.Select(c => c.City).Distinct();
            return Json(cities);
        
        }

        public IActionResult Districts(string city) { 
           var districts = _context.Address.Where(a=>a.City == city).Select(a=>a.SiteId).Distinct();
            return Json(districts);

        }
    }
}
