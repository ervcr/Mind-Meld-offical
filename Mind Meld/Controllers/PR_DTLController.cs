using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mind_Meld.Areas.Identity.Data;
using Mind_Meld.Models;

namespace Mind_Meld.Controllers
{
    public class PR_DTLController : Controller
    {
        private readonly DBContextMindMeld _db;

        public PR_DTLController(DBContextMindMeld db)
        {
            _db = db;
        }


        public ActionResult Index()
        {

            var product_Request = _db.PR_DTL
                 .Include(p => p.PurchRequest)
                .Include(p => p.Product)
                .ToList();

            return View(product_Request);
        }

       
        public ActionResult Create()
        {
            PR_DTL pR_DTL = new PR_DTL();

            // Populate ViewBag for Product Names
            ViewBag.ProductNames = new SelectList(_db.Product, "ProdID", "Name");

            // Populate ViewBag for Purchase Requests
            ViewBag.Requests = new SelectList(_db.PurchRequest, "RequestID", "RequestDate");


            return View(pR_DTL);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PR_DTL pR_DTL)
        {
            // Populate ViewBag for Product Names
            ViewBag.ProductNames = new SelectList(_db.Product, "ProdID", "Name");

            // Populate ViewBag for Purchase Requests
            ViewBag.Requests = new SelectList(_db.PurchRequest, "RequestID", "RequestID");

            _db.PR_DTL.Add(pR_DTL);
            _db.SaveChanges();
            TempData["AlertMessage"] = "Purchase Request Added Successfully";
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            var pR_DTL = _db.PR_DTL.Find(id);

            ViewBag.ProductNames = new SelectList(_db.Product, "ProdID", "Name");
            ViewBag.Requests = new SelectList(_db.PurchRequest, "RequestID", "RequestDate");

            if (id == 0)
            {
                return NotFound();
            }

            if(pR_DTL == null)
            {
                return NotFound();
            }

            return View(pR_DTL);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PR_DTL pR_DTL)
        {
            ViewBag.ProductNames = new SelectList(_db.Product, "ProdID", "Name");
            ViewBag.Requests = new SelectList(_db.PurchRequest, "RequestID", "RequestDate");

            if (pR_DTL == null)
            {
                return NotFound();
            }

            _db.Update(pR_DTL);
            _db.SaveChanges();
            TempData["AlertMessageEdit"] = "Department Edited Successfully";

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var prDtl = _db.PR_DTL
        .Include(p => p.Product) // Include the Product navigation property
        .FirstOrDefault(m => m.PR_DTLid == id);

            if (prDtl == null)
            {
                return NotFound();
            }

            return View(prDtl);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var prDtl = _db.PR_DTL.Find(id);

            if (prDtl == null)
            {
                return NotFound();
            }

            _db.PR_DTL.Remove(prDtl);
            _db.SaveChanges();
            TempData["AlertMessageDelete"] = "PR Detail deleted successfully.";

            return RedirectToAction("Index");
        }

    }
}
