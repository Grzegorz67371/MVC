using Microsoft.EntityFrameworkCore;
using CyfrowaBiblioteka.Models;

namespace CyfrowaBiblioteka.Data
{
    public class BibliotekaContext : DbContext
    {
        public BibliotekaContext(DbContextOptions<BibliotekaContext> opcje) : base(opcje)
        {
        }

        public DbSet<Ksiazka> Ksiazki { get; set; }
        public DbSet<Autor> Autorzy { get; set; }
        public DbSet<Wypozyczenie> Wypozyczenia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>().HasData(
                new Autor { Id = 1, ImieNazwisko = "George R. R. Martin" },
                new Autor { Id = 2, ImieNazwisko = "Rick Riordan" },
                new Autor { Id = 3, ImieNazwisko = "Antoine de Saint-Exupéry" }
            );

            modelBuilder.Entity<Ksiazka>().HasData(
                new Ksiazka { Id = 1, Tytul = "A Game of Thrones", RokWydania = 1996, AutorId = 1 },
                new Ksiazka { Id = 2, Tytul = "Percy Jackson: Złodziej pioruna", RokWydania = 2005, AutorId = 2 },
                new Ksiazka { Id = 3, Tytul = "Mały książe", RokWydania = 1943, AutorId = 3 }
            );
        }
    }
}
