using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using QuickscanMvc.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using QuickscanBusinessLogicLayer.Container;
using QuickscanDAL;
using QuickscanBusinessLogicLayer;

namespace QuickscanMvc.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction();
        }

        private void Set(string key, string value, int? expireTime)
        {
            CookieOptions option = new();
            if (expireTime.HasValue)
            {
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            }
            else
            {
                option.Expires = DateTime.Now.AddMinutes(15);
            }

            Response.Cookies.Append(key, value, option);
        }

        [HttpPost]
        public IActionResult Login(GebruikerModel gebruiker)
        {
            GebruikerContainer loginContainer = new(new GebruikerDAL());
            Gebruiker newgebruiker = new();
            if (ModelState.IsValid)
            {
                 newgebruiker = new(gebruiker.GebruikersNaam, gebruiker.Wachtwoord);
            }

            if (loginContainer.ControleerGegevens(newgebruiker) == true)
            {
                Gebruiker DatabaseGebruiker = loginContainer.GetGebruikerType(newgebruiker);

                Set("GebruikerGegevens", "de gebruikers username en userId", null);
                HttpContext.Session.SetString("GebruikersNaam", DatabaseGebruiker.Gebruikersnaam);
                HttpContext.Session.SetInt32("GebruikerId", DatabaseGebruiker.GebruikerID);
                HttpContext.Session.SetString("GebruikerType", DatabaseGebruiker.Type);
    
                return RedirectToAction("Index", "Schoolgebouw");
            }            
            else
            {
                ViewBag.Error = "Inloggen mislukt";
            }
            return View("Index");
        }
    }
}
