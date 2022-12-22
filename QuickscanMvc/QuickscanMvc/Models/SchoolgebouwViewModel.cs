namespace QuickscanMvc.Models
{
    public class SchoolgebouwViewModel
    {
        public int SchoolGebouwID { get; set; }
        public int GemeenteNr { get; set; }
        public string GebouwNaam { get; set; }
        public string Straatnaam { get; set; }
        public string Postcode { get; set; }
        public int Huisnummer { get; set; }
        public string Onderwijssoort { get; set; }
        public int Bouwjaar { get; set; }
        public int Oppervlakte { get; set; }
        public int AantalLeerlingen { get; set; }
        public string ContactpersoonNaam { get; set; }
        public string ContactpersoonFunctie { get; set; }
        public string ContactpersoonTelefoonNr { get; set; }
        public string ContactpersoonEmail { get; set; }
        public string Stad { get; set; }
    }
}
