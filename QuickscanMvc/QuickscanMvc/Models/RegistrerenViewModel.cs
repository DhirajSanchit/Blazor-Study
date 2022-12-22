using System.ComponentModel.DataAnnotations;

namespace QuickscanMvc.Models
{
    public class RegistrerenViewModel
    {
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Must be at least 4 characters long.")]

        public string Voornaam { get; set; }
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Must be at least 4 characters long.")]

        public string Achternaam { get; set; }
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Must be at least 4 characters long.")]

        public string Wachtwoord { get; set; }
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Must be at least 4 characters long.")]

        public string GebruikersNaam { get; set; }
        //[Range(1,20)]
        public int GemeenteNummer { get; set; }
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Must be at least 4 characters long.")]

        public string Type { get; set; }
    }
}
