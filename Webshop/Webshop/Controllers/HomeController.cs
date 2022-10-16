using System.Diagnostics;
using InterfaceLayer.Containers;
using Microsoft.AspNetCore.Mvc;
using Webshop.Models;

namespace Webshop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductContainer _container;
    
    public HomeController(ILogger<HomeController> logger, IProductContainer productContainer)
    {
        _logger = logger;
        _container = productContainer;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    public IActionResult Products()
    {
        ProductViewModel pvm = new();
        pvm._products = _container.GetAllProducts();
        return View(pvm);
    }
    
    public IActionResult ProductDetails(int id)
    {
        ProductViewModel pvm = new();
        pvm.Dto = _container.GetProductById(id);
        return View(pvm.Dto);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}