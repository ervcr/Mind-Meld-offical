using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mind_Meld.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Mind_Meld.Areas.Identity.Data;
using Mind_Meld.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Mind_Meld.Controllers
{
    public class DashbroadController : Controller
    {
        private readonly DBContextMindMeld _db;
        public DashbroadController(DBContextMindMeld db)
        {
            _db = db;
        }

        /*
        * Sub System One
        * Be aware one the names of ur Dashboard NAMES
        * E.G AdminDashboardOne() - Is for ur admin
        * I add one for u to see that is sub system one
        * 
        */
        public ActionResult AdminDashboardOne()
        {
            return View();
        }

        //Sales Emp Dashboard
        public ActionResult SalesEmpDashboard()
        {
            return View();
        }

        //Custumer Dashboard
        public ActionResult CustumerDashboard()
        {
            return View();
        }

        /*
         * Sub System two
         * Your adived not to touch 
         * If u touch let me know so that I can be aware
         */
        public ActionResult AdminDashboard()
        {
            var employees = _db.Employee.Include(e => e.User).Include(e => e.Dept).ToList();
            return View(employees);
        }

        public ActionResult DeptEmpDashboard()
        {
            List<Product> products = _db.Product.Include(p => p.Supplier).ToList(); // Retrieve all products from the database
            return View(products);
        }

        public ActionResult PurchEmpDashboard()
        {
            List<Product> products = _db.Product.Include(p => p.Supplier).ToList(); // Retrieve all products from the database
            return View(products);
        }

    }
}
