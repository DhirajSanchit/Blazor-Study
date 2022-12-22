using System.Diagnostics;
using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webshop.Models;

namespace Webshop.Controllers;

[Authorize(Policy = "Customer")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProofOfConceptsContainer _container;
    private INotyfService _notyfService;

    public HomeController(ILogger<HomeController> logger, IProofOfConceptsContainer container, INotyfService notyfService)
    {
        _logger = logger;
        _container = container;
        _notyfService = notyfService;
    }

     
    public IActionResult Index()
    {
        ///TODO: remove code below, is for a viewcomponent for Quickscan 
        
        try
        {
            // var model = _container.GetAllSamples();
            return View();
        } 
        catch (Exception e)
        {
            _notyfService.Error("Unknown error");
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
    
    public Task<IActionResult> AccessDenied()
    {
        _notyfService.Warning("You are not allowed to access this page");

        if (User.IsInRole("Admin") || User.IsInRole("ShopOwner"))
        {
            return Task.FromResult<IActionResult>(RedirectToAction("Index", "Admin"));
        }

        return Task.FromResult<IActionResult>(RedirectToAction("Index", "Home"));
    }
    
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}