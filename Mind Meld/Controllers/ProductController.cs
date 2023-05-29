using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mind_Meld.Areas.Identity.Data;
using Mind_Meld.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Mind_Meld.Controllers
{
    public class ProductController : Controller
    {
        private readonly DBContextMindMeld _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(DBContextMindMeld db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public ActionResult Index()
        {
            List<Product> products = _db.Product.Include(p => p.Supplier).ToList(); // Retrieve all products from the database
            return View(products);
        }
        public ActionResult ViewProducts()
        {
            List<Product> products = _db.Product.ToList(); // Retrieve all products from the database
            return View(products);
        }

        public ActionResult Create()
        {
            Product product = new Product();
            ViewBag.Suppliers = new SelectList(_db.Supplier, "SuppID", "Name");
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BarCode, Name, Description, Image, Price, SuppID")] Product product)
        {
                // Save image file
                if (product.Image != null && product.Image.Length > 0)
                {
                    string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    string uniqueFileName = $"{Guid.NewGuid().ToString()}_{product.Image.FileName}";
                    string filePath = Path.Combine(uploadsDir, uniqueFileName);

                    // Create the directory if it doesn't exist
                    Directory.CreateDirectory(uploadsDir);

                    await product.Image.CopyToAsync(new FileStream(filePath, FileMode.Create));
                    product.ImagePath = uniqueFileName; // Save the image path in the database
                }

                _db.Product.Add(product);
                await _db.SaveChangesAsync();
                TempData["AlertMessage"] = "Product Added Successfully";
                return RedirectToAction(nameof(Index));
        }

     
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _db.Product.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            // Populate suppliers for the dropdown
            ViewBag.Suppliers = new SelectList(_db.Supplier, "SuppID", "Name");

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.ProdID)
            {
                return NotFound();
            }

            // Populate suppliers for the dropdown
            ViewBag.Suppliers = new SelectList(_db.Supplier, "SuppID", "Name");
           
                try
                {
                    // Save image file
                    if (product.Image != null)
                    {
                        string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                        string uniqueFileName = $"{Guid.NewGuid().ToString()}_{product.Image.FileName}";
                        string filePath = Path.Combine(uploadsDir, uniqueFileName);
                        await product.Image.CopyToAsync(new FileStream(filePath, FileMode.Create));
                        product.ImagePath = uniqueFileName; // Save the image path in the database
                    }

                    _db.Update(product);
                    await _db.SaveChangesAsync();
                    TempData["AlertMessageEdit"] = "Product Edited Successfully";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProdID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _db.Product.Any(e => e.ProdID == id);
        }

        public ActionResult Details(int id)
        {
            var products = _db.Product.ToList();
            return View(products);
        }


        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
