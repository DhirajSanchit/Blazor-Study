using Microsoft.AspNetCore.Mvc;
using QuickscanBusinessLogicLayer;
using QuickscanBusinessLogicLayer.Container;
using QuickscanDAL;
using QuickscanMvc.Models;

namespace QuickscanMvc.Controllers
{
    public class AdviesController : Controller
    {
        public IActionResult AdviesView(int schoolgebouwId)
        {
            schoolgebouwId = 9;
            Beoordelingsformulier beoordelingsformulier = AdviesDataOphalen(schoolgebouwId);

            AdviesViewModel adviesViewModel = new AdviesViewModel()
            {
                AdviesId = beoordelingsformulier.Id,
                AdviesScore = beoordelingsformulier.Advies.Score,
                Datum = beoordelingsformulier.Advies.Datum,
                Opmerking = beoordelingsformulier.Advies.Opmerking,
                UitstralingScore = beoordelingsformulier.Uitstraling.Score,
                BouwkundigestaatScore = beoordelingsformulier.BouwkundigeStaat.ScoreBerekenen(),
                VeiligheidScore = beoordelingsformulier.Veiligheid.ScoreBerekenen(),
                EnergieVerbruikScore = beoordelingsformulier.EnergieVerbruik.ScoreBerekenen(),
                OnderwijskundigeStaatScore = beoordelingsformulier.OnderwijskundigeStaat.ScoreBerekenen()
            };

            return View(adviesViewModel);
        }


        private Beoordelingsformulier AdviesDataOphalen(int schoolgebouwId)
        {
            SchoolgebouwContainer schoolgebouwContainer = new SchoolgebouwContainer(new SchoolgebouwDAL());
            BeoordelingsFormulierContainer beoordelingsformulierContainer = new BeoordelingsFormulierContainer(new BeoordelingsformulierDAL());

            Schoolgebouw schoolgebouw = schoolgebouwContainer.GetSchoolgebouwByID(schoolgebouwId);
            Beoordelingsformulier beoordelingsformulier = new Beoordelingsformulier(schoolgebouw);
            beoordelingsformulier.Id = beoordelingsformulierContainer.IdOphalenMetGebouwId(schoolgebouw.SchoolGebouwID);

            beoordelingsformulier = beoordelingsformulierContainer.AntwoordenOphalen(beoordelingsformulier, new BeoordelingsformulierDAL());

            return beoordelingsformulier;
        }
    }
}
