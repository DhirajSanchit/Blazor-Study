using System.Data.SqlClient;
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
    private readonly IProofOfConceptsContainer _container;
    private INotyfService _notyf;

    public HomeController(ILogger<HomeController> logger, IProofOfConceptsContainer container, INotyfService notyf)
    {
        _logger = logger;
        _container = container;
        _notyf = notyf;
    }

     
    public IActionResult Index()
    {
        ///TODO: remove code below, is for a viewcomponent for Quickscan 
        
        try
        {
            var model = _container.GetAllSamples();
            return View(model);
        }
        // catch (SqlException e)
        // {
        //     _notyf.Error("Database error");
        //     _logger.LogError(e, "Database error");
        // }
        catch (Exception e)
        {
            _notyf.Error("Unknown error");
            _logger.LogError(e, "Unknown error");
        }
        return View();
    }

    public IActionResult Privacy()
    {
        //Route used for notyf library and toast notifications types
        // _notyf.Custom("Custom Notification - closes in 5 seconds.", 5, "whitesmoke", "fa fa-gear");
        // _notyf.Custom("Custom Notification - closes in 10 seconds.", 10, "#B600FF", "fa fa-home");
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}