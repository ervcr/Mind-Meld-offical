using Microsoft.AspNetCore.Mvc;
using Mind_Meld.Areas.Identity.Data;
using Mind_Meld.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace Mind_Meld.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DBContextMindMeld _db;

        public EmployeeController(DBContextMindMeld db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            var employees = _db.Employee.Include(e => e.User).Include(e => e.Dept).ToList();
            return View(employees);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            Employee employee = new Employee();

            ViewBag.Departments = new SelectList(_db.Dept.ToList(), "DeptID", "DeptName");
            ViewBag.Users = new SelectList(_db.Users.ToList(), "Id", "FirstName");

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            ViewBag.Departments = new SelectList(_db.Dept.ToList(), "DeptID", "DeptName");
            ViewBag.Users = new SelectList(_db.Users.ToList(), "Id", "FirstName");

            var user = employee.User != null ? _db.Users.Find(employee.User.Id) : null;

            employee.User = user;

            _db.Employee.Add(employee);
            _db.SaveChanges();
            TempData["AlertMessage"] = "Department Added Successfully";
            return RedirectToAction("Index");
        }

       [HttpGet]
        public ActionResult Edit(int id)
        {
            var employee = _db.Employee.Find(id);
            ViewBag.Departments = new SelectList(_db.Dept.ToList(), "DeptID", "DeptName");
            ViewBag.Users = new SelectList(_db.Users.ToList(), "Id", "FirstName");

            if (id == null)
            {
                return NotFound();
            }

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee employee)
        {
            ViewBag.Departments = new SelectList(_db.Dept.ToList(), "DeptID", "DeptName");
            ViewBag.Users = new SelectList(_db.Users.ToList(), "Id", "FirstName");

            if (id != employee.Id)
            {
                return NotFound();
            }

            _db.Update(employee);
            _db.SaveChanges();
            TempData["AlertMessageEdit"] = "Department Edited Successfully";

            return RedirectToAction("Index");
        }
        private bool DeptExists(int id)
        {
            return _db.Employee.Any(e => e.Id == id);
        }


        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController/Delete/5
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
