using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using QuickscanBusinessLogicLayer;
using QuickscanBusinessLogicLayer.Container;
using QuickscanDAL;
using QuickscanMvc.Models;

namespace QuickscanMvc.Components;

public class FormsProgressBar : ViewComponent
{
    
    List<ProgressViewModel> progressList = new List<ProgressViewModel>();
    IDictionary<string, int> categoryTitles = new Dictionary<string, int>();

    private int BarColor = 0;
    
    //DI for the Container
    SchoolgebouwContainer schoolgebouwContainer = new SchoolgebouwContainer(new SchoolgebouwDAL());

    BeoordelingsFormulierContainer beoordelingsFormulierContainer =
        new BeoordelingsFormulierContainer(new BeoordelingsformulierDAL());
    //DI within constructor
    
    //TODO: invoke method to calculte and return div for progress.
    public IViewComponentResult Invoke(int schoolId)
    {
        return View(CalculateProgress(schoolId));
        //return View();
    }


    private ProgressViewModel CalculateProgress(int id)
    {

        var total = 0.0;
        var actual = 0;
        double progress = 0.0;
        ProgressViewModel Pbvm = new ProgressViewModel();
        BarColor = 0;
        
        Schoolgebouw schoolgebouw = this.schoolgebouwContainer.GetSchoolgebouwByID(id);
        Beoordelingsformulier beoordelingsformulier = new Beoordelingsformulier(schoolgebouw);
        beoordelingsformulier =
            beoordelingsFormulierContainer.AntwoordenOphalen(beoordelingsformulier, new BeoordelingsformulierDAL());

        var Form = beoordelingsformulier.GetType();

        //Loop over each property in the beoordelingsformulier
        foreach (var category in Form.GetProperties())
        {
            //Acces fields of each forms category
            var formCategory = category.GetType();

            //Get the property value name
            var categoryValue = category.GetValue(beoordelingsformulier);   
            categoryTitles.Add(categoryValue.ToString(), 0);
            
            var amountOfProperties = categoryValue.GetType().GetProperties().Length;
            
            //get the amount of properties in the categoryValue
            total += amountOfProperties;

            //Check in beoordelingsformulier if the category is filled in
            
            //Check the name of the current category
            Pbvm.categories.Add(categoryValue.ToString(), 0);
            

            if (categoryValue != null)
            {
                //Loop over each property in the category
                foreach (var property in categoryValue.GetType().GetProperties())
                {
                    //Get the property value name
                    var propertyValue = property.GetValue(categoryValue);
                    //Check if the property is filled in
                    if (propertyValue != null)
                    {
                        //Check if the property is a string
                        if (propertyValue.GetType() == typeof(string))
                        {
                            //Check if the string is not empty
                            if (propertyValue.ToString().IsNullOrEmpty() || propertyValue.ToString() != null)
                            {
                                actual++;
                            }
                        }
                        else
                        {
                            actual += 0;
                        }
                    }
                }
            }
            
            try
            {
                Pbvm.progress = actual / total * 100;
                Pbvm.progress = Math.Round(Pbvm.progress, 0);
                // categoryTitles[] = (int)Pbvm.progress;
                Pbvm.categories[categoryValue.ToString()] = (int)Pbvm.progress;
                //Pbvm.Color = Pbvm.colors[currentColor];
                Pbvm.ColorId = BarColor;
                
            }
            catch (DivideByZeroException dbze)
            {
                Console.WriteLine(dbze.Message);
                Pbvm.progress = 0;
                return Pbvm;
            }
            BarColor++;

        }
        return Pbvm;

    }
    
    
}
