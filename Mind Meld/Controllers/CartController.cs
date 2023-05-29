using Microsoft.AspNetCore.Mvc;
using Mind_Meld.Areas.Identity.Data;
//using Mind_Meld.Migrations;
using Mind_Meld.Models;

namespace Mind_Meld.Controllers
{
    public class CartController : Controller
    {
        private readonly DBContextMindMeld _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CartController(DBContextMindMeld db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
            //List<Product> products = _db.Product.ToList(); // Retrieve all products from the database
            //return View(products);
        }

        //public ActionResult AddToCart(int id)
        //{
        //    //// Retrieve product details from the database based on the provided ID
        //    //Product product = _db.Product.Find(id);

        //    //// Create a new cart item with the retrieved product details
        //    //Cart cartItem = new Cart
        //    //{
        //    //    ProdID = product.Id,
        //    //    Name = product.Name,
        //    //    Description = product.Description,
        //    //    Price = product.Price,
        //    //    Quantity = 1 // Default quantity is 1, but you can adjust as needed
        //    //};

        //    //// Add the cart item to the user's cart (e.g., store it in a session variable)
        //    //List<CartItem> cart = Session["Cart"] as List<CartItem>;
        //    //if (cart == null)
        //    //{
        //    //    cart = new List<CartItem>();
        //    //    Session["Cart"] = cart;
        //    //}

        //    //cart.Add(cartItem);

        //    //// Redirect the user to the cart view
        //    //return RedirectToAction("Cart");
        //}
    }
}
