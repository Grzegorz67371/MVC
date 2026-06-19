using System.ComponentModel.DataAnnotations;

namespace CyfrowaBiblioteka.Models
{
    public class Autor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Podaj imię i nazwisko autora")]
        [Display(Name = "Imię i nazwisko")]
        public string ImieNazwisko { get; set; }

        // jeden autor moze miec wiele ksiazek
        public List<Ksiazka> Ksiazki { get; set; } = new List<Ksiazka>();
    }
}
