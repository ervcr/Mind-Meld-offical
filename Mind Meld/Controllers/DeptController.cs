using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Mind_Meld.Areas.Identity.Data;
using Mind_Meld.Models;
using System.Net;
 
namespace Mind_Meld.Controllers
{
    public class DeptController : Controller
    {
        private readonly DBContextMindMeld _db;

        public DeptController(DBContextMindMeld db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Dept> Dept = _db.Dept.ToList();    
            return View(Dept);
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dept dept = _db.Dept.Find(id);

            if (dept == null)
            {
                return NotFound();
            }

            return View(dept);
        }

        public ActionResult Create()
        {
            Dept dept = new Dept();
            return View(dept);
        }

        [HttpPost]
        public ActionResult Create(Dept dept)
        {

            _db.Dept.Add(dept);
            _db.SaveChanges();
            TempData["AlertMessage"] = "Department Added Successfully";
            return RedirectToAction("Index");   

        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dept = _db.Dept.Find(id);
            if (dept == null)
            {
                return NotFound();
            }

            return View(dept);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, Dept dept)
        {
            if (id != dept.DeptID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(dept);
                    _db.SaveChanges();
                    TempData["AlertMessageEdit"] = "Department Edited Successfully";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeptExists(dept.DeptID))
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

            return View(dept);
        }

        private bool DeptExists(string id)
        {
            return _db.Dept.Any(e => e.DeptID == id);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dept = _db.Dept.FirstOrDefault(d => d.DeptID == id);
            if (dept == null)
            {
                return NotFound();
            }

            return View(dept);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var dept = _db.Dept.FirstOrDefault(d => d.DeptID == id);
            if (dept == null)
            {
                return NotFound();
            }

            _db.Dept.Remove(dept);
            _db.SaveChanges();
            TempData["AlertMessageDelete"] = "Department Deleted Successfully";
            return RedirectToAction(nameof(Index));
        }

    }
}
