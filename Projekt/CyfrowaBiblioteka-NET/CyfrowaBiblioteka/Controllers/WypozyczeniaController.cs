using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CyfrowaBiblioteka.Data;
using CyfrowaBiblioteka.Models;

namespace CyfrowaBiblioteka.Controllers
{
    public class WypozyczeniaController : Controller
    {
        private readonly BibliotekaContext db;

        public WypozyczeniaController(BibliotekaContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            var wypozyczenia = db.Wypozyczenia.Include(w => w.Ksiazka).ToList();
            return View(wypozyczenia);
        }

        public IActionResult Create()
        {
            ViewBag.Ksiazki = new SelectList(db.Ksiazki, "Id", "Tytul");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Wypozyczenie wypozyczenie)
        {
            if (ModelState.IsValid)
            {
                db.Wypozyczenia.Add(wypozyczenie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Ksiazki = new SelectList(db.Ksiazki, "Id", "Tytul", wypozyczenie.KsiazkaId);
            return View(wypozyczenie);
        }

        public IActionResult Edit(int id)
        {
            var wypozyczenie = db.Wypozyczenia.Find(id);
            if (wypozyczenie == null)
                return NotFound();

            ViewBag.Ksiazki = new SelectList(db.Ksiazki, "Id", "Tytul", wypozyczenie.KsiazkaId);
            return View(wypozyczenie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Wypozyczenie wypozyczenie)
        {
            if (ModelState.IsValid)
            {
                db.Wypozyczenia.Update(wypozyczenie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Ksiazki = new SelectList(db.Ksiazki, "Id", "Tytul", wypozyczenie.KsiazkaId);
            return View(wypozyczenie);
        }

        public IActionResult Delete(int id)
        {
            var wypozyczenie = db.Wypozyczenia.Include(w => w.Ksiazka).FirstOrDefault(w => w.Id == id);
            if (wypozyczenie == null)
                return NotFound();

            return View(wypozyczenie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePotwierdzone(int id)
        {
            var wypozyczenie = db.Wypozyczenia.Find(id);
            if (wypozyczenie != null)
            {
                db.Wypozyczenia.Remove(wypozyczenie);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
