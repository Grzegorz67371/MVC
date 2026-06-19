using System.ComponentModel.DataAnnotations;

namespace CyfrowaBiblioteka.Models
{
    public class Ksiazka
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tytuł jest wymagany")]
        public string Tytul { get; set; }

        [Display(Name = "Rok wydania")]
        [Range(0, 3000, ErrorMessage = "Podaj poprawny rok wydania")]
        public int RokWydania { get; set; }

        // relacja do autora
        [Display(Name = "Autor")]
        public int AutorId { get; set; }
        public Autor Autor { get; set; }

        // jedna ksiazka moze byc wypozyczana wiele razy
        public List<Wypozyczenie> Wypozyczenia { get; set; } = new List<Wypozyczenie>();
    }
}
