using Microsoft.AspNetCore.Mvc;
using QuickscanBusinessLogicLayer.Container;
using QuickscanBusinessLogicLayer;
using QuickscanDAL;
using QuickscanMvc.Models;

namespace QuickscanMvc.Controllers
{
    public class BeoordelingsFormulierController : Controller
    {
        SchoolgebouwContainer schoolgebouwContainer = new SchoolgebouwContainer(new SchoolgebouwDAL());
        BeoordelingsFormulierContainer beoordelingsFormulierContainer = new BeoordelingsFormulierContainer(new BeoordelingsformulierDAL());
        Beoordelingsformulier beoordelingsformulier;
        public IActionResult Index()
        {
            int id = 0;
            if (TempData["schoolgebouwId"] != null)
            {
                id = (int)TempData["schoolgebouwId"];

            }
            Schoolgebouw schoolgebouw = schoolgebouwContainer.GetSchoolgebouwByID(id);
            beoordelingsformulier = new Beoordelingsformulier(schoolgebouw);
            beoordelingsformulier.Id = beoordelingsFormulierContainer.IdOphalenMetGebouwId(schoolgebouw.SchoolGebouwID);

            beoordelingsformulier = beoordelingsFormulierContainer.AntwoordenOphalen(beoordelingsformulier, new BeoordelingsformulierDAL());


            BeoordelingsFormulierViewModel beoordelingsFormulierViewModel = this.NaarBeoordelingsFormulierViewModel(beoordelingsformulier);
            beoordelingsFormulierViewModel.ReadOnly = true;
            return View(beoordelingsFormulierViewModel);
        }

        public IActionResult BeoordelingsformulierInzien()
        {
            int id = 0;
            if (TempData["schoolgebouwId"] != null)
            {
                id = (int)TempData["schoolgebouwId"];

            }
            Schoolgebouw schoolgebouw = schoolgebouwContainer.GetSchoolgebouwByID(id);
            beoordelingsformulier = new Beoordelingsformulier(schoolgebouw);
            beoordelingsformulier.Id = beoordelingsFormulierContainer.IdOphalenMetGebouwId(schoolgebouw.SchoolGebouwID);

            beoordelingsformulier = beoordelingsFormulierContainer.AntwoordenOphalen(beoordelingsformulier, new BeoordelingsformulierDAL());


            BeoordelingsFormulierViewModel beoordelingsFormulierViewModel = this.NaarBeoordelingsFormulierViewModel(beoordelingsformulier);
            return View(beoordelingsFormulierViewModel);
        }
        public IActionResult RuimtebehoefteBvoToevoegen(BeoordelingsFormulierViewModel bfvm)
        {
            Beoordelingsformulier beoordelingsformulier = new Beoordelingsformulier();

            beoordelingsformulier.Ruimtebehoefte.LeerlingenToevoegen = bfvm.LeerlingenToevoegen;
            beoordelingsformulier.Ruimtebehoefte.JaarToevoegen = bfvm.JaarToevoegen;
            beoordelingsformulier.Id = bfvm.Id;
            beoordelingsFormulierContainer.RuimtebehoefteOpslaan(beoordelingsformulier);
            TempData["schoolgebouwId"] = bfvm.SchoolGebouwId;
            return RedirectToAction("Index");
        }
        public IActionResult RuimtebehoefteVerwijderen(int id, int schoolId)
        {
            beoordelingsFormulierContainer.RuimtebehoefteVerwijderen(id);
            TempData["schoolgebouwId"] =  schoolId;
            return RedirectToAction("Index");
        }

        public IActionResult SchoolGebouwEdit(int id)
        {
            Schoolgebouw schoolgebouw = this.schoolgebouwContainer.GetSchoolgebouwByID(id);
            Beoordelingsformulier beoordelingsformulier = new Beoordelingsformulier(schoolgebouw);
            beoordelingsformulier = beoordelingsFormulierContainer.AntwoordenOphalen(beoordelingsformulier, new BeoordelingsformulierDAL());

            BeoordelingsFormulierViewModel beoordelingsformulierViewModel = this.NaarBeoordelingsFormulierViewModel(beoordelingsformulier);
            beoordelingsformulierViewModel.ReadOnly = false;
            return View("Index", beoordelingsformulierViewModel);
        }

        public IActionResult SchoolgebouwOpslaan(BeoordelingsFormulierViewModel bfvm)
        {
            Schoolgebouw schoolgebouw = this.NaarSchoolgebouw(bfvm);
            this.schoolgebouwContainer.SchoolgebouwUpdaten(schoolgebouw);

            TempData["schoolgebouwId"] = bfvm.SchoolGebouwId;
            return RedirectToAction("Index");
        }

        public IActionResult AntwoordenOpslaan(BeoordelingsFormulierViewModel bfvm)
        {
            Beoordelingsformulier beoordelingsformulier = this.NaarBeoordelingsFormulier(bfvm);
            this.beoordelingsFormulierContainer.AntwoordenOpslaan(beoordelingsformulier);
            
            TempData["schoolgebouwId"] = bfvm.SchoolGebouwId;
            return RedirectToAction("Index");
        }

        private BeoordelingsFormulierViewModel NaarBeoordelingsFormulierViewModel(Beoordelingsformulier beoordelingsformulier)
        {
            BeoordelingsFormulierViewModel beoordelingsFormulierViewModel = new BeoordelingsFormulierViewModel()
            {
                Id = beoordelingsformulier.Id,
                //schoolgebouw
                SchoolGebouwId = beoordelingsformulier.Schoolgebouw.SchoolGebouwID,
                GemeenteNr = beoordelingsformulier.Schoolgebouw.GemeenteNr,
                SchoolgebouwNaam = beoordelingsformulier.Schoolgebouw.GebouwNaam,
                Straatnaam = beoordelingsformulier.Schoolgebouw.Straatnaam,
                Postcode = beoordelingsformulier.Schoolgebouw.Postcode,
                Huisnummer = beoordelingsformulier.Schoolgebouw.Huisnummer,
                Onderwijssoort = beoordelingsformulier.Schoolgebouw.Onderwijssoort,
                Bouwjaar = beoordelingsformulier.Schoolgebouw.Bouwjaar,
                Oppervlakte = beoordelingsformulier.Schoolgebouw.Oppervlakte,
                AantalLeerlingen = beoordelingsformulier.Schoolgebouw.AantalLeerlingen,
                ContactpersoonEmail = beoordelingsformulier.Schoolgebouw.ContactpersoonEmail,
                ContactpersoonFunctie = beoordelingsformulier.Schoolgebouw.ContactpersoonFunctie,
                ContactpersoonNaam = beoordelingsformulier.Schoolgebouw.ContactpersoonNaam,
                ContactpersoonTelefoonNr = beoordelingsformulier.Schoolgebouw.ContactpersoonTelefoonNr,

                //ruimtebehoefte
                Leerlingen = beoordelingsformulier.Ruimtebehoefte.Leerlingen,
                Jaar = beoordelingsformulier.Ruimtebehoefte.Jaar,
                BVOs = beoordelingsformulier.Ruimtebehoefte.BVOBerekenen(beoordelingsformulier.Schoolgebouw),
                RuimteBehoefteIds = beoordelingsformulier.Ruimtebehoefte.Id,
                //uitstraling
                radioUitstraling = beoordelingsformulier.Uitstraling.Score.ToString(),
                UitstralingOpmerking = beoordelingsformulier.Uitstraling.Opmerking,

                //bouwkundige staat
                Dak = beoordelingsformulier.BouwkundigeStaat.Dak,
                Gevel = beoordelingsformulier.BouwkundigeStaat.Gevel,
                Kozijnen = beoordelingsformulier.BouwkundigeStaat.Kozijnen,
                Verwarming = beoordelingsformulier.BouwkundigeStaat.Verwarming,
                Sanitair = beoordelingsformulier.BouwkundigeStaat.Sanitair,
                Riolering = beoordelingsformulier.BouwkundigeStaat.Riolering,
                Wanden = beoordelingsformulier.BouwkundigeStaat.Wanden,
                KostenPerJaar = beoordelingsformulier.BouwkundigeStaat.KostenPerJaar,
                SubsidiePerJaar = beoordelingsformulier.BouwkundigeStaat.SubsidiePerJaar,
                RenovatieJaar = beoordelingsformulier.BouwkundigeStaat.RenovatieJaar,
                BouwkundigeStaatExtraPuntSliders = beoordelingsformulier.BouwkundigeStaat.ExtraPuntSliders,
                BouwkundigeStaatExtraPuntKosten = beoordelingsformulier.BouwkundigeStaat.ExtraPuntKosten,
                BouwkundigeStaatOpmerking = beoordelingsformulier.BouwkundigeStaat.Opmerking,

                //veiligheid
                radioVeiligheid = beoordelingsformulier.Veiligheid.CheckBoxScore.ToString(),
                VeiligheidExtraScore = beoordelingsformulier.Veiligheid.ExtraScore,
                VeiligheidOpmerking = beoordelingsformulier.Veiligheid.Opmerking,

                //energieverbruik
                VerbruikElektriciteit = beoordelingsformulier.EnergieVerbruik.VerbruikElektriciteit,
                VerbruikGas = beoordelingsformulier.EnergieVerbruik.VerbruikGas,
                VerbruikStadsverwarming = beoordelingsformulier.EnergieVerbruik.VerbruikStadverwarming,
                EigenOpwekking = beoordelingsformulier.EnergieVerbruik.EigenOpwekking,
                EnergieVerbruikOpmerking = beoordelingsformulier.EnergieVerbruik.Beschrijving,

                //onderwijskundige staat
                Aula = beoordelingsformulier.OnderwijskundigeStaat.Aula,
                Stafruimte = beoordelingsformulier.OnderwijskundigeStaat.Stafruimte,
                Bergruimte = beoordelingsformulier.OnderwijskundigeStaat.Bergruimte,
                Rolstoel = beoordelingsformulier.OnderwijskundigeStaat.Rolstoel,
                OnderwijskundigeStaatOpmerking = beoordelingsformulier.OnderwijskundigeStaat.Beschrijving,



            };
            return beoordelingsFormulierViewModel;
        }

        private Beoordelingsformulier NaarBeoordelingsFormulier(BeoordelingsFormulierViewModel beoordelingsFormulierViewModel)
        {
            BouwkundigeStaat bouwkundigeStaat = this.NaarBouwkundigeStaat(beoordelingsFormulierViewModel);
            Veiligheid veiligheid = this.NaarVeiligheid(beoordelingsFormulierViewModel);
            EnergieVerbruik energieVerbruik = this.NaarEnergieVerbruik(beoordelingsFormulierViewModel);
            OnderwijskundigeStaat onderwijskundigeStaat = this.NaarOnderwijskundigeStaat(beoordelingsFormulierViewModel);
            Uitstraling uitstraling = this.NaarUitstraling(beoordelingsFormulierViewModel);

            Beoordelingsformulier beoordelingsFormulier = new Beoordelingsformulier(beoordelingsFormulierViewModel.Id, bouwkundigeStaat, veiligheid, energieVerbruik, onderwijskundigeStaat, uitstraling);
            return beoordelingsFormulier;
        }


        private Uitstraling NaarUitstraling(BeoordelingsFormulierViewModel bfvm)
        {
            Uitstraling uitstraling = new Uitstraling()
            {
                Score = Convert.ToDouble(bfvm.radioUitstraling),
                Opmerking = bfvm.UitstralingOpmerking
            };
            return uitstraling;
        }

        private BouwkundigeStaat NaarBouwkundigeStaat(BeoordelingsFormulierViewModel bfvm)
        {
            BouwkundigeStaat bouwkundigeStaat = new BouwkundigeStaat()
            {
                Dak = bfvm.Dak,
                Gevel = bfvm.Gevel,
                Kozijnen = bfvm.Kozijnen,
                Verwarming = bfvm.Verwarming,
                Sanitair = bfvm.Sanitair,
                Riolering = bfvm.Riolering,
                Wanden = bfvm.Wanden,
                KostenPerJaar = bfvm.KostenPerJaar,
                SubsidiePerJaar = bfvm.SubsidiePerJaar,
                RenovatieJaar = bfvm.RenovatieJaar,
                ExtraPuntKosten = bfvm.BouwkundigeStaatExtraPuntKosten,
                ExtraPuntSliders = bfvm.BouwkundigeStaatExtraPuntSliders,
                Bouwjaar = bfvm.Bouwjaar,
                Opmerking = bfvm.BouwkundigeStaatOpmerking
            };
            return bouwkundigeStaat;
        }

        private Veiligheid NaarVeiligheid(BeoordelingsFormulierViewModel bfvm)
        {
            Veiligheid veiligheid = new Veiligheid()
            {
                CheckBoxScore = Convert.ToDouble(bfvm.radioVeiligheid),
                ExtraScore = bfvm.VeiligheidExtraScore,
                Opmerking = bfvm.VeiligheidOpmerking
            };
            return veiligheid;
        }

        private EnergieVerbruik NaarEnergieVerbruik(BeoordelingsFormulierViewModel bfvm)
        {
            EnergieVerbruik energieVerbruik = new EnergieVerbruik()
            {
                VerbruikElektriciteit = bfvm.VerbruikElektriciteit,
                VerbruikGas = bfvm.VerbruikGas,
                VerbruikStadverwarming = bfvm.VerbruikStadsverwarming,
                EigenOpwekking = bfvm.EigenOpwekking,
                Oppervlakte = bfvm.Oppervlakte,
                Beschrijving = bfvm.EnergieVerbruikOpmerking
            };
            return energieVerbruik;
        }

        private OnderwijskundigeStaat NaarOnderwijskundigeStaat(BeoordelingsFormulierViewModel bfvm)
        {
            OnderwijskundigeStaat onderwijskundigeStaat = new OnderwijskundigeStaat()
            {
                Aula = bfvm.Aula,
                Stafruimte = bfvm.Stafruimte,
                Bergruimte = bfvm.Bergruimte,
                Rolstoel = bfvm.Rolstoel,
                Beschrijving = bfvm.OnderwijskundigeStaatOpmerking
            };
            return onderwijskundigeStaat;
        }
        
        private Schoolgebouw NaarSchoolgebouw(BeoordelingsFormulierViewModel bfvm)
        {
            Schoolgebouw schoolgebouw = new Schoolgebouw()
            {
                SchoolGebouwID = bfvm.SchoolGebouwId,
                AantalLeerlingen = bfvm.AantalLeerlingen,
                Bouwjaar = bfvm.Bouwjaar,
                ContactpersoonEmail = bfvm.ContactpersoonEmail,
                ContactpersoonFunctie = bfvm.ContactpersoonFunctie,
                ContactpersoonNaam = bfvm.ContactpersoonNaam,
                ContactpersoonTelefoonNr = bfvm.ContactpersoonTelefoonNr,
                GebouwNaam = bfvm.SchoolgebouwNaam,
                GemeenteNr = bfvm.GemeenteNr,
                Huisnummer = bfvm.Huisnummer,
                Onderwijssoort = bfvm.Onderwijssoort,
                Oppervlakte = bfvm.Oppervlakte,
                Postcode = bfvm.Postcode,
                Stad = bfvm.Stad,
                Straatnaam = bfvm.Straatnaam,
            };
            return schoolgebouw;
        }

        public IActionResult AdviesGenereren(int id)
        {
            Schoolgebouw schoolgebouw = schoolgebouwContainer.GetSchoolgebouwByID(id);
            beoordelingsformulier = new Beoordelingsformulier(schoolgebouw);
            beoordelingsformulier.Id = beoordelingsFormulierContainer.IdOphalenMetGebouwId(schoolgebouw.SchoolGebouwID);

            beoordelingsformulier = beoordelingsFormulierContainer.AntwoordenOphalen(beoordelingsformulier, new BeoordelingsformulierDAL());

            bool succes = this.beoordelingsFormulierContainer.AdviesOpslaan(beoordelingsformulier);

            if (succes)
            {
                return RedirectToAction("Index", "Schoolgebouw");
                
            }
            else
            {
                return RedirectToAction("Index", new {});
            }
        }
    }
}
