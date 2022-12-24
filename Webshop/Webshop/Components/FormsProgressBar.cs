using System.Reflection;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Webshop.Models;
using Webshop.Models.Components;

namespace Webshop.Components;

public class FormsProgressBar : ViewComponent
{
    private IProofOfConceptsContainer _container;

    public FormsProgressBar(IProofOfConceptsContainer container)
    {
        _container = container;
    }

    //TODO: invoke method to calculte and return div for progress.
    public IViewComponentResult Invoke(int id)
    {
        return View(CalculateProgress(id));
    }


    private FormsProgressBarModel CalculateProgress(int id)
    {
        var total = 0.0;
        var actual = 0;
        var progress = 0.0;
        FormsProgressBarModel Pbvm = new FormsProgressBarModel();

        var data = _container.GetSampleDtoById(id);
        var form = data.GetType();
        total = form.GetProperties().Length;
        //Loop over each property in the beoordelingsformulier
        foreach (PropertyInfo category in form.GetProperties())
        {
            try
            {
                var value = category.GetValue(data, null);
                if (value != null || String.IsNullOrWhiteSpace(value.ToString()))
                {
                    actual++;
                }

                Pbvm.Progress = actual / total * 100;
                
            }
            catch (NullReferenceException nre)
            {
                actual += 0;
            }
            catch (ArgumentNullException ane)
            {
                actual += 0;
            }
            catch (DivideByZeroException ane)
            {
                Console.WriteLine(ane.Message);
                Pbvm.Progress = 0;
                return Pbvm;
            }
            catch (Exception ex)
            {
                actual += 0;
            }
        }
        return Pbvm;
    }


    // {
    //     var total = 0.0;
    //     var actual = 0;
    //
    //     var  data = _container.GetSampleDtoById(id);
    //     var form = data.GetType();
    //    
    //     //Loop over each property in the beoordelingsformulier
    //     foreach(PropertyInfo category in form.GetProperties())
    //     {
    //         var Type = category.GetType();
    //         //loop over each category of beoordelingsformulier 
    //         foreach(PropertyInfo field in Type.GetProperties())
    //         {
    //             total += Type.GetProperties().Length;
    //           
    //             if(field != null)
    //             {
    //                 actual++;
    //             }
    //         }
    //     }
    //     data.Progress = actual / total * 100;;
    //     return data;
    // }
}