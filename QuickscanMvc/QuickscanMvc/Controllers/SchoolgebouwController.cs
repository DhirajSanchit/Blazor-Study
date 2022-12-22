using Microsoft.AspNetCore.Mvc;
using QuickscanBusinessLogicLayer.Container;
using QuickscanBusinessLogicLayer;
using QuickscanDAL;
using QuickscanMvc.Models;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Http;

namespace QuickscanMvc.Controllers
{
    public class SchoolgebouwController : Controller
    {
        SchoolgebouwContainer schoolgebouwContainer = new (new SchoolgebouwDAL());
        BeoordelingsFormulierContainer beoordelingsFormulierContainer = new(new BeoordelingsformulierDAL());
        public IActionResult Index()
        {
            HoofdpaginaViewModel hoofdpaginaViewModel = new();
            List<Schoolgebouw> schoolgebouwen = this.schoolgebouwContainer.GetAllSchoolgebouwen();
            hoofdpaginaViewModel.schoolgebouwViewModels = this.SchoolgebouwenNaarViewModels(schoolgebouwen);
            hoofdpaginaViewModel.GebruikerType = ViewBag.GebruikerId = HttpContext.Session.GetString("GebruikerType");
            return View(hoofdpaginaViewModel);
        }

        public IActionResult NaarBeoordelingsFormulier(int id)
        {
            TempData["schoolgebouwId"] = id;
            return RedirectToAction("Index", "BeoordelingsFormulier");
        }

        public IActionResult NaarBeoordelingsFormulierInzien(int id)
        {
            TempData["schoolgebouwId"] = id;
            return RedirectToAction("BeoordelingsformulierInzien", "BeoordelingsFormulier");
        }

        private List<SchoolgebouwViewModel> SchoolgebouwenNaarViewModels(List<Schoolgebouw> schoolgebouwen)
        {
            List<SchoolgebouwViewModel> schoolgebouwViewModels = new();
            foreach (Schoolgebouw schoolgebouw in schoolgebouwen)
            {
                SchoolgebouwViewModel schoolgebouwViewModel = new()
                {
                    SchoolGebouwID = schoolgebouw.SchoolGebouwID,
                    GemeenteNr = schoolgebouw.GemeenteNr,
                    GebouwNaam = schoolgebouw.GebouwNaam,
                    Straatnaam = schoolgebouw.Straatnaam,
                    Postcode = schoolgebouw.Postcode,
                    Huisnummer = schoolgebouw.Huisnummer,
                    Onderwijssoort = schoolgebouw.Onderwijssoort,
                    Bouwjaar = schoolgebouw.Bouwjaar,
                    Oppervlakte = schoolgebouw.Oppervlakte,
                    AantalLeerlingen = schoolgebouw.AantalLeerlingen,
                    ContactpersoonNaam = schoolgebouw.ContactpersoonNaam,
                    ContactpersoonFunctie = schoolgebouw.ContactpersoonFunctie,
                    ContactpersoonTelefoonNr = schoolgebouw.ContactpersoonTelefoonNr,
                    ContactpersoonEmail = schoolgebouw.ContactpersoonEmail,
                    Stad = schoolgebouw.Stad
                };
                schoolgebouwViewModels.Add(schoolgebouwViewModel);
            }
            return schoolgebouwViewModels;
        }


        public IActionResult SorteerButton(HoofdpaginaViewModel hoofdpaginaViewModel, string naam)
        {
            SorteerContainer sorteerContainer = new(new SorteerDAL());
            List<Schoolgebouw> gesorteerdeSchoolgebouwen = sorteerContainer.SorteerList(naam);
            hoofdpaginaViewModel.schoolgebouwViewModels = SchoolgebouwenNaarViewModels(gesorteerdeSchoolgebouwen);
            hoofdpaginaViewModel.GebruikerType = ViewBag.GebruikerId = HttpContext.Session.GetString("GebruikerType");
            return View("Index", hoofdpaginaViewModel);
        }

        public IActionResult FilterButton(HoofdpaginaViewModel hoofdpaginaViewModel)
        {
            SorteerContainer sorteerContainer = new(new SorteerDAL());
            List<Schoolgebouw> GefilterdeSchoolgebouwen = sorteerContainer.FilterList(hoofdpaginaViewModel.DropdownValue, hoofdpaginaViewModel.FilterText);
            hoofdpaginaViewModel.schoolgebouwViewModels = SchoolgebouwenNaarViewModels(GefilterdeSchoolgebouwen);
            hoofdpaginaViewModel.GebruikerType = ViewBag.GebruikerId = HttpContext.Session.GetString("GebruikerType");
            return View("Index", hoofdpaginaViewModel);
        }

        [HttpPost]
        public IActionResult RegisterButton()
        {
            return RedirectToAction("Index", "Registratie");
        }

        public IActionResult Aanmaken()
        {
            //naar aanmaken view
            return View();
        }
        public IActionResult SchoolgebouwAanmaken(SchoolgebouwViewModel svm)
        {
            //aanmaken form uitvoeren
            Schoolgebouw schoolgebouw = new(svm.SchoolGebouwID, svm.GemeenteNr, svm.GebouwNaam, svm.Stad, svm.Straatnaam, svm.Postcode, svm.Huisnummer, svm.Onderwijssoort, svm.Bouwjaar, svm.Oppervlakte, svm.AantalLeerlingen, svm.ContactpersoonNaam, svm.ContactpersoonFunctie, svm.ContactpersoonTelefoonNr, svm.ContactpersoonEmail);
            int schoolgebouwId = this.schoolgebouwContainer.SchoolgebouwAanmaken(schoolgebouw);
            this.beoordelingsFormulierContainer.BeoordelingsformulierAanmaken(schoolgebouwId);
            return RedirectToAction("Index");
        }
    }
}
