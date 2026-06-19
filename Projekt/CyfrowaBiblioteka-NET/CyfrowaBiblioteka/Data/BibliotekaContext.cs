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
            // dane startowe zeby baza nie byla pusta
            modelBuilder.Entity<Autor>().HasData(
                new Autor { Id = 1, ImieNazwisko = "Rick Riordan" },
                new Autor { Id = 2, ImieNazwisko = "Antoine de Saint-Exupéry" },
                new Autor { Id = 3, ImieNazwisko = "George R.R. Martin" }
            );

            modelBuilder.Entity<Ksiazka>().HasData(
                new Ksiazka { Id = 1, Tytul = "Percy Jackson: Złodziej pioruna", RokWydania = 2005, AutorId = 1 },
                new Ksiazka { Id = 2, Tytul = "Mały Książę", RokWydania = 1943, AutorId = 2 },
                new Ksiazka { Id = 3, Tytul = "Gra o Tron", RokWydania = 1996, AutorId = 3 }
            );
        }
    }
}
