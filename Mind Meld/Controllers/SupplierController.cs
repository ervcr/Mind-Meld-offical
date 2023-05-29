using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mind_Meld.Areas.Identity.Data;
//using Mind_Meld.Migrations;
using Mind_Meld.Models;

namespace Mind_Meld.Controllers
{
    public class SupplierController : Controller
    {

        private readonly DBContextMindMeld _db;

        public SupplierController(DBContextMindMeld db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            List<Supplier> supplier = _db.Supplier.ToList();
            return View(supplier);
        }
        public ActionResult MaintainSupplier()
        {
            List<Supplier> supplier = _db.Supplier.ToList();
            return View(supplier);
        }

        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Supplier supplier = _db.Supplier.Find(id);

            if (id == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        public ActionResult Create()
        {
            Supplier supplier = new Supplier();
            return View(supplier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier supplier)
        {
            _db.Supplier.Add(supplier);
            _db.SaveChanges();
            TempData["AlertMessage"] = "Supplier Added Successfully";
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = _db.Supplier.Find(id);

            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Supplier supplier)
        {
            if (id != supplier.SuppID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(supplier);
                    _db.SaveChanges();
                    TempData["AlertMessageEdit"] = "Supplier Edited Successfully";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeptExists(supplier.SuppID))
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

            return View(supplier);
        }

        private bool DeptExists(int id)
        {
            return _db.Supplier.Any(e => e.SuppID == id);
        }

        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = _db.Supplier.FirstOrDefault(d => d.SuppID == id);
            if (id == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var supplier = _db.Supplier.FirstOrDefault(d => d.SuppID == id);
           
            if (supplier == null)
            {
                return NotFound();
            }

            _db.Supplier.Remove(supplier);
            _db.SaveChanges();
            TempData["AlertMessageDelete"] = "Supplier Deleted Successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
