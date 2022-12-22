namespace QuickscanMvc.Models
{
    public class BeoordelingsFormulierViewModel
    {
        public int Id { get; set; }

        //schoolgebouw
        public int SchoolGebouwId { get; set; }
        public int GemeenteNr { get; set; }
        public string SchoolgebouwNaam { get; set; }
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

        //ruimtebehoefte
        public List<double> BVOs { get; set; }
        public List<int> Jaar { get; set; }
        public List<int> Leerlingen { get; set; }
        public List<int> RuimteBehoefteIds { get; set; }

        public int JaarToevoegen { get; set; }
        public int LeerlingenToevoegen { get; set; }

        //uitstraling
        public string radioUitstraling { get; set; }
        public string UitstralingOpmerking { get; set; }

        //bouwkundige staat
        public int Dak { get; set; }
        public int Gevel { get; set; }
        public int Kozijnen { get; set; }
        public int Verwarming { get; set; }
        public int Sanitair { get; set; }
        public int Riolering { get; set; }
        public int Wanden { get; set; }
        public double KostenPerJaar { get; set; }
        public double SubsidiePerJaar { get; set; }
        public int RenovatieJaar { get; set; }
        public double BouwkundigeStaatExtraPuntSliders { get; set; }
        public double BouwkundigeStaatExtraPuntKosten { get; set; }
        public string BouwkundigeStaatOpmerking { get; set; }

        //veiligheid
        public string radioVeiligheid { get; set; }
        public double VeiligheidExtraScore { get; set; }
        public string VeiligheidOpmerking { get; set; }

        //energieverbruik
        public string EnergieVerbruikOpmerking { get; set; }
        public double VerbruikElektriciteit { get; set; }
        public double VerbruikGas { get; set; }
        public double VerbruikStadsverwarming { get; set; }
        public double EigenOpwekking { get; set; }

        //onderwijskundige staat
        public string OnderwijskundigeStaatOpmerking { get; set; }
        public int Aula { get; set; }
        public int Stafruimte { get; set; }
        public int Bergruimte { get; set; }
        public int Rolstoel { get; set; }

        //readonly
        public bool ReadOnly { get; set; }

    }
}
