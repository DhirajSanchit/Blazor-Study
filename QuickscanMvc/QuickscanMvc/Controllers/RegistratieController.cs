using QuickscanMvc.Models;
using Microsoft.AspNetCore.Mvc;
using QuickscanBusinessLogicLayer.Container;
using QuickscanDAL;
using QuickscanBusinessLogicLayer;
using QuickscanInterfaces.Interface;
using Windows.UI.Xaml.Controls;

namespace QuickscanMvc.Controllers
{
    public class RegistratieController : Controller
    {
        public IActionResult Index()
       {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }
           return View();
       }

 

        public IActionResult Registreren(RegistrerenViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                GebruikerContainer login = new GebruikerContainer(new GebruikerDAL());
                Gebruiker newgebruiker = new(rvm.GemeenteNummer, rvm.Voornaam, rvm.Achternaam, rvm.GebruikersNaam, rvm.Type, rvm.Wachtwoord);
                if (newgebruiker.Type == "Monteur")
                {
                    Gebruiker newgebruikerMonteur = new(rvm.Voornaam, rvm.Achternaam, rvm.GebruikersNaam, rvm.Type, rvm.Wachtwoord);
                    if (login.checkSpecialChar(newgebruikerMonteur) == true)
                    {
                        ViewBag.Error = "Gebruikersnaam is ongeldig";
                        return View("Index");
                    }
                    else
                    {
                        if (login.GebruikerRegistreren(newgebruikerMonteur) == false)
                        {
                            ViewBag.Error = "Gebruikersnaam is al in gebruik";
                            return View("Index");
                        } else
                        {
                            TempData["Message"] = "Registratie compleet";

                            return RedirectToAction("Index");


                        }

                    }

                }
                else
                { if (newgebruiker.GemeenteNr == 0 || newgebruiker.GemeenteNr >=20)
                    {

                        ViewBag.Errormessage = "The field GemeenteNummer must be between 1 and 20";
                        return View("Index");
                    }
                    if(login.checkSpecialChar(newgebruiker) == true)
                    {
                        ViewBag.Error = "Gebruikersnaam is ongeldig";
                        return View("Index");
                    } else
                    {
                        if (login.GebruikerRegistreren(newgebruiker) == false)
                        {
                            ViewBag.Error = "Gebruikersnaam is al in gebruik";
                            return View("Index");
                        } else
                        {
                            TempData["Message"] = "Registratie compleet";
                            return RedirectToAction("Index");

                        }

                    }

                }
            }
            return View("Index");

        }
    }
}
