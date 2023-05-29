using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mind_Meld.Areas.Identity.Data;
using Mind_Meld.Models;

namespace Mind_Meld.Controllers
{
    public class QuoteController : Controller
    {
        private readonly DBContextMindMeld _db;

        public QuoteController(DBContextMindMeld db)
        {
            _db = db;
        }

        // GET: QuoteController
        public ActionResult Index()
        {
            List<Quote> quotes = _db.Quote.ToList();
            return View(quotes);
        }

        // GET: QuoteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: QuoteController/Create
        public ActionResult Create()
        {
            Quote quote = new    Quote();
            return View(quote);
        }

        // POST: QuoteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Quote quote)
        {
            _db.Quote.Add(quote);
            _db.SaveChanges();
            TempData["AlertMessage"] = "Quote Added Successfully";
            return RedirectToAction("Index");

        }

        // GET: QuoteController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quote = _db.Quote.Find(id);
            if (quote == null)
            {
                return NotFound();
            }

            return View(quote);
        }

        // POST: QuoteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Quote quote)
        {
            if (id != quote.QuoteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(quote);
                    _db.SaveChanges();
                    TempData["AlertMessageEdit"] = "Quote Edited Successfully";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuoteExists(quote.QuoteID))
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

            return View(quote);
        }
        private bool QuoteExists(int id)
        {
            return _db.Quote.Any(e => e.QuoteID == id);
        }

        // GET: QuoteController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quote = _db.Quote.FirstOrDefault(d => d.QuoteID == id);
            if (quote == null)
            {
                return NotFound();
            }

            return View(quote);
        }

        // POST: QuoteController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var quote = _db.Quote.FirstOrDefault(d => d.QuoteID == id);
            if (quote == null)
            {
                return NotFound();
            }

            _db.Quote.Remove(quote);
            _db.SaveChanges();
            TempData["AlertMessageDelete"] = "Quote Deleted Successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
