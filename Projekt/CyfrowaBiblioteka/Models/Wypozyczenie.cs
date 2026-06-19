using System.ComponentModel.DataAnnotations;

namespace CyfrowaBiblioteka.Models
{
    public class Wypozyczenie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Podaj kto wypożycza książkę")]
        [Display(Name = "Kto wypożycza")]
        public string Czytelnik { get; set; }

        [Display(Name = "Data wypożyczenia")]
        [DataType(DataType.Date)]
        public DateTime DataWypozyczenia { get; set; } = DateTime.Today;

        [Display(Name = "Data zwrotu")]
        [DataType(DataType.Date)]
        public DateTime? DataZwrotu { get; set; }

        // relacja do ksiazki
        [Display(Name = "Książka")]
        public int KsiazkaId { get; set; }
        public Ksiazka Ksiazka { get; set; }
    }
}
