using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Mind_Meld.Areas.Identity.Data;
//using Mind_Meld.Migrations;
using Mind_Meld.Models;
using System.Diagnostics;

namespace Mind_Meld.Controllers
{
    public class HomeController : Controller
    {
        private readonly DBContextMindMeld _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger , DBContextMindMeld db, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Product> products = _db.Product.ToList(); // Retrieve all products from the database
            return View(products);
            
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