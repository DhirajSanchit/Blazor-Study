using System.Diagnostics;
using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessLogicLayer.Classes;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Webshop.Models;

namespace Webshop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductContainer _container;
    private INotyfService _notyf;

    public HomeController(ILogger<HomeController> logger, IProductContainer productContainer, INotyfService notyf)
    {
        _logger = logger;
        _container = productContainer;
        _notyf = notyf;
    }

    //TODO: Adjust shopping cart to nullable returns
    public IActionResult Index()
    {
        SampleModel model = new SampleModel();
        SampleModel getter = null;
        if (_container.GetSampleDtoById(1)  == null)
        {
            // _notyf.Error("Error");
            model.Id = 0;
            model.Value= "No Record Found";
        }
        else
        {
            model = getter;
        }
        return View(model);
    }

    public IActionResult Privacy()
    {
        _notyf.Custom("Custom Notification - closes in 5 seconds.", 5, "whitesmoke", "fa fa-gear");
        _notyf.Custom("Custom Notification - closes in 10 seconds.", 10, "#B600FF", "fa fa-home");
       
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}