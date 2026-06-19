using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CyfrowaBiblioteka.Data;
using CyfrowaBiblioteka.Models;

namespace CyfrowaBiblioteka.Controllers
{
    public class KsiazkiController : Controller
    {
        private readonly BibliotekaContext db;

        public KsiazkiController(BibliotekaContext context)
        {
            db = context;
        }

        // wyszukiwanie po tytule i filtrowanie po autorze
        public IActionResult Index(string szukaj, int? autorId)
        {
            var ksiazki = db.Ksiazki.Include(k => k.Autor).AsQueryable();

            if (!string.IsNullOrEmpty(szukaj))
            {
                ksiazki = ksiazki.Where(k => k.Tytul.Contains(szukaj));
            }

            if (autorId != null)
            {
                ksiazki = ksiazki.Where(k => k.AutorId == autorId);
            }

            ViewBag.Autorzy = new SelectList(db.Autorzy, "Id", "ImieNazwisko", autorId);
            ViewBag.Szukaj = szukaj;

            return View(ksiazki.ToList());
        }

        public IActionResult Details(int id)
        {
            var ksiazka = db.Ksiazki
                .Include(k => k.Autor)
                .Include(k => k.Wypozyczenia)
                .FirstOrDefault(k => k.Id == id);

            if (ksiazka == null)
                return NotFound();

            return View(ksiazka);
        }

        public IActionResult Create()
        {
            ViewBag.Autorzy = new SelectList(db.Autorzy, "Id", "ImieNazwisko");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ksiazka ksiazka)
        {
            if (ModelState.IsValid)
            {
                db.Ksiazki.Add(ksiazka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Autorzy = new SelectList(db.Autorzy, "Id", "ImieNazwisko", ksiazka.AutorId);
            return View(ksiazka);
        }

        public IActionResult Edit(int id)
        {
            var ksiazka = db.Ksiazki.Find(id);
            if (ksiazka == null)
                return NotFound();

            ViewBag.Autorzy = new SelectList(db.Autorzy, "Id", "ImieNazwisko", ksiazka.AutorId);
            return View(ksiazka);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Ksiazka ksiazka)
        {
            if (ModelState.IsValid)
            {
                db.Ksiazki.Update(ksiazka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Autorzy = new SelectList(db.Autorzy, "Id", "ImieNazwisko", ksiazka.AutorId);
            return View(ksiazka);
        }

        public IActionResult Delete(int id)
        {
            var ksiazka = db.Ksiazki.Include(k => k.Autor).FirstOrDefault(k => k.Id == id);
            if (ksiazka == null)
                return NotFound();

            return View(ksiazka);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePotwierdzone(int id)
        {
            var ksiazka = db.Ksiazki.Find(id);
            if (ksiazka != null)
            {
                db.Ksiazki.Remove(ksiazka);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
