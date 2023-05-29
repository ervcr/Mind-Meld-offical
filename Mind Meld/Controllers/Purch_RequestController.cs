using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mind_Meld.Areas.Identity.Data;
using Mind_Meld.Models;

namespace Mind_Meld.Controllers
{
    public class Purch_RequestController : Controller
    {
        private readonly DBContextMindMeld _db;

        public Purch_RequestController(DBContextMindMeld db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Purch_Request> purch_request = _db.Purch_Request.ToList();
            return View(purch_request);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            Purch_Request purch_Request = new Purch_Request();

            ViewBag.UserEmp = new SelectList(_db.Users.ToList(), "Id", "FirstName");

            return View(purch_Request);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Purch_Request purch_Request)
        {
            ViewBag.UserEmp = new SelectList(_db.Users.ToList(), "Id", "FirstName");

            if (ModelState.IsValid)
            {
                _db.Purch_Request.Add(purch_Request);
                _db.SaveChanges();
                TempData["AlertMessage"] = "Purchase Request Added Successfully";
                return RedirectToAction(nameof(Index));
            }

            return View(purch_Request);
        }

        // GET: Purch_RequestController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Purch_RequestController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: Purch_RequestController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Purch_RequestController/Delete/5
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
