using System.ComponentModel.DataAnnotations;

namespace QuickscanMvc.Models
{
    public class GebruikerModel
    {
        [StringLength(20, MinimumLength =1)]
        [Required]
        public string GebruikersNaam { get; set; }
        [StringLength(20, MinimumLength =1)]
        [Required]
        public string Wachtwoord { get; set; }
    }
}
