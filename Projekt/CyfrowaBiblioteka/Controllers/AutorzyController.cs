using Microsoft.AspNetCore.Mvc;
using CyfrowaBiblioteka.Data;
using CyfrowaBiblioteka.Models;
using Microsoft.EntityFrameworkCore;

namespace CyfrowaBiblioteka.Controllers
{
    public class AutorzyController : Controller
    {
        private readonly BibliotekaContext db;

        public AutorzyController(BibliotekaContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            var autorzy = db.Autorzy.Include(a => a.Ksiazki).ToList();
            return View(autorzy);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Autor autor)
        {
            if (ModelState.IsValid)
            {
                db.Autorzy.Add(autor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(autor);
        }

        public IActionResult Edit(int id)
        {
            var autor = db.Autorzy.Find(id);
            if (autor == null)
                return NotFound();

            return View(autor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Autor autor)
        {
            if (ModelState.IsValid)
            {
                db.Autorzy.Update(autor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(autor);
        }

        public IActionResult Delete(int id)
        {
            var autor = db.Autorzy.Find(id);
            if (autor == null)
                return NotFound();

            return View(autor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePotwierdzone(int id)
        {
            var autor = db.Autorzy.Find(id);
            if (autor != null)
            {
                db.Autorzy.Remove(autor);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
