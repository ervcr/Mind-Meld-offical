using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mind_Meld.Areas.Identity.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mind_Meld.Models;
using Microsoft.EntityFrameworkCore;

namespace Mind_Meld.Controllers
{
    public class PurchRequestController : Controller
    {
        private readonly DBContextMindMeld _db;

        public PurchRequestController(DBContextMindMeld db)
        {
            _db = db;
        }


        public ActionResult Index()
        {
            List<PurchRequest> purch_request = _db.PurchRequest.Include(p => p.User).ToList();
            return View(purch_request);
        }
        public ActionResult listPurchRequest()
        {
            List<PurchRequest> purch_request = _db.PurchRequest.Include(p => p.User).ToList();
            return View(purch_request);
        }

        public ActionResult Create()
        {
            PurchRequest purchRequest = new PurchRequest();
            ViewBag.UserID = new SelectList(_db.Users.ToList(), "Id", "FirstName");
            return View(purchRequest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PurchRequest purchRequest)
        {
            ViewBag.UserID = new SelectList(_db.Users.ToList(), "Id", "FirstName");

            _db.PurchRequest.Add(purchRequest);
            _db.SaveChanges();
            TempData["AlertMessage"] = "Purchase Request Added Successfully";
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            var purchRequest = _db.PurchRequest.Find(id);
            ViewBag.UserID = new SelectList(_db.Users.ToList(), "Id", "FirstName");

            if (id == null)
            {
                return NotFound();
            }

            if (purchRequest == null)
            {
                return NotFound();
            }

            return View(purchRequest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PurchRequest purchRequest)
        {
           // var purchRequest = _db.PurchRequest.Find(id);
            ViewBag.UserID = new SelectList(_db.Users.ToList(), "Id", "FirstName");

            if (purchRequest == null)
            {
                return NotFound();
            }
            _db.Update(purchRequest);
            _db.SaveChanges();
            TempData["AlertMessageEdit"] = "Department Edited Successfully";

            return RedirectToAction("Index");
        }
        private bool DeptExists(int id)
        {
            return _db.PurchRequest.Any(e => e.RequestID == id);
        }
        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            PurchRequest purchRequest = _db.PurchRequest.Find(id);

            if (purchRequest == null)
            {
                return NotFound();
            }

            return View(purchRequest);
        }

    }
}
