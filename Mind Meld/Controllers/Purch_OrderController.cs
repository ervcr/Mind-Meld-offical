using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mind_Meld.Areas.Identity.Data;
using Mind_Meld.Models;

namespace Mind_Meld.Controllers
{
    public class Purch_OrderController : Controller
    {
        private readonly DBContextMindMeld _db;
        public Purch_OrderController(DBContextMindMeld db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            var model = _db.Purch_Order
             .Include(po => po.PurchRequest)
             .Include(po => po.Supplier)
             .ToList();

            return View(model);
        }

        // GET: Purch_OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public IActionResult Create()
        {
            Purch_Order purch_Order = new Purch_Order();
            ViewBag.PurchRequestList = new SelectList(_db.PurchRequest, "RequestID", "RequestDate");
            ViewBag.SupplierList = new SelectList(_db.Supplier, "SuppID", "Name");
            return View(purch_Order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Purch_Order purch_Order)
        {
            ViewBag.PurchRequestList = new SelectList(_db.PurchRequest, "RequestID", "RequestDate");
            ViewBag.SupplierList = new SelectList(_db.Supplier, "SuppID", "Name");
           
            _db.Purch_Order.Add(purch_Order);
            _db.SaveChanges();
            TempData["AlertMessage"] = " purch Order Added Successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchOrder = _db.Purch_Order
                .Include(po => po.PurchRequest)
                .Include(po => po.Supplier)
                .FirstOrDefault(m => m.OrderID == id);

            if (purchOrder == null)
            {
                return NotFound();
            }

            return View(purchOrder);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var purchOrder = _db.Purch_Order.Find(id);

            if (purchOrder == null)
            {
                return NotFound();
            }

            _db.Purch_Order.Remove(purchOrder);
            _db.SaveChanges();
            TempData["AlertMessageDelete"] = "Purch_Order successfully deleted.";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            ViewBag.PurchRequestList = new SelectList(_db.PurchRequest, "RequestID", "RequestDate");
            ViewBag.SupplierList = new SelectList(_db.Supplier, "SuppID", "Name");
            if (id == null)
            {
                return NotFound();
            }

            var purchOrder = _db.Purch_Order.Find(id);
            if (purchOrder == null)
            {
                return NotFound();
            }

            return View(purchOrder);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Purch_Order purchOrder)
        {
            if (id != purchOrder.OrderID)
            {
                return NotFound();
            }

            var existingPurchOrder = _db.Purch_Order.Find(id);
            if (existingPurchOrder == null)
            {
                return NotFound();
            }

            existingPurchOrder.POProgress = purchOrder.POProgress;

            _db.SaveChanges();
            TempData["AlertMessageEdit"] = "Purchase Order successfully updated.";
            return RedirectToAction("Index");
        }



    }
}
