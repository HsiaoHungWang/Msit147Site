using Microsoft.AspNetCore.Mvc;
using Msit147Site.Models;

namespace Msit147Site.Controllers
{
    public class ApiController : Controller
    {
        private readonly DemoContext _context;
        private readonly IWebHostEnvironment _host;
        public ApiController(DemoContext context, IWebHostEnvironment host)
        {
            _context = context;
            _host = host;
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
            System.Threading.Thread.Sleep(10000);

            return Content($"Hello {userName}!!");
        }

        [HttpPost]
        public IActionResult Register(Members member, IFormFile Photo) {
            // string photoInfo = $"{Photo.FileName} - {Photo.Length} - {Photo.ContentType}";
            string rootPath = Path.Combine(_host.WebRootPath, "uploads", Photo.FileName); //C:\Users\User\Documents\Ajax\Msit147Site\wwwroot
            using(var fileStream = new FileStream(rootPath, FileMode.Create))
            {
                Photo.CopyTo(fileStream);
            }
            return Content(rootPath);
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
